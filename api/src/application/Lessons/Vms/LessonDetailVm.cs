using Domain;

namespace Application.Lessons
{
    public class LessonDetailVm
    {
        public string Title { get; set; }
        public int LessonNo { get; set; }
        public string VideoContentType { get; set; }

        public LessonDetailVm(Lesson lesson)
        {
            Title = lesson.Title;
            LessonNo = lesson.LessonNo;
            VideoContentType = $"video/{lesson.Video.FileType}";
        }
    }
}
