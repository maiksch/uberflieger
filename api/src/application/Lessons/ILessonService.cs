using System.IO;
using System.Threading.Tasks;

namespace Application.Lessons
{
    public interface ILessonService
    {
        Task<LessonDetailVm> GetOne(string moduleIdentifier, int lessonNo);
        Task<(Stream, string)> GetVideo(int id);
    }
}
