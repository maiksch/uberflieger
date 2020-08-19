using Domain;

namespace Application.Lessons
{
    public class LessonDetailVm
    {
        public string Title { get; set; }

        public LessonDetailVm(Lesson lesson)
        {
            Title = lesson.Title;
        }
    }
}
