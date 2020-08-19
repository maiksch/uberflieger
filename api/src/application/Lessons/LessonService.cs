using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly UberfliegerContext _context;
        public LessonService(UberfliegerContext context)
        {
            _context = context;
        }

        public async Task<LessonDetailVm> GetOne(string moduleIdentifier, int lessonNo)
        {
            var lesson = await _context.Lessons.Include(l => l.Module)
                                               .Where(l => l.Module.Identifier == moduleIdentifier && l.LessonNo == lessonNo)
                                               .SingleAsync();
            
            if (lesson == null)
            {
                return null;
            }

            return new LessonDetailVm(lesson);
        }
    }
}
