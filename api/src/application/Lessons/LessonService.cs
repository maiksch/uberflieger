using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly UberfliegerContext _context;
        private readonly BlobContainerClient _blobContainer;

        public LessonService(UberfliegerContext context, BlobContainerClient blobContainer)
        {
            _context = context;
            _blobContainer = blobContainer;
        }

        public async Task<LessonDetailVm> GetOne(string moduleIdentifier, int lessonNo)
        {
            var lesson = await _context.Lessons.Include(l => l.Module)
                                               .ThenInclude(m => m.Product)
                                               .Include(l => l.Video)
                                               .Where(l => l.Module.Identifier == moduleIdentifier && l.LessonNo == lessonNo)
                                               .SingleAsync();

            if (lesson == null)
            {
                return null;
            }

            return new LessonDetailVm(lesson);
        }

        public async Task<(Stream, string)> GetVideo(int id)
        {
            var lesson = await _context.Lessons.Include(l => l.Video).Where(l => l.Id == id).SingleOrDefaultAsync();
            if (lesson == null)
            {
                return (null, null);
            }

            var blobClient = _blobContainer.GetBlobClient($"{lesson.Video.StorageId}.{lesson.Video.FileType}");

            var memoryStream = new MemoryStream();

            await blobClient.DownloadToAsync(memoryStream, null, new StorageTransferOptions
            {
                InitialTransferLength = 1024 * 1024,
                MaximumConcurrency = 20,
                MaximumTransferLength = 4 * 1024 * 1024
            });

            return (memoryStream, lesson.Video.FileType);
        }
    }
}
