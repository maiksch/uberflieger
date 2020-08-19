using System.Threading.Tasks;

namespace Application.Lessons
{
    public interface ILessonService
    {
        Task<LessonDetailVm> GetOne(string moduleIdentifier, int id);
    }
}
