using Domain;

namespace Application.Lessons
{
    public class LessonDetailVm_Module
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
    }

    public class LessonDetailVm_Product
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
    }

    public class LessonDetailVm
    {
        public string Title { get; set; }
        public int LessonNo { get; set; }
        public string VideoContentType { get; set; }
        public LessonDetailVm_Module Module { get; set; }
        public LessonDetailVm_Product Product { get; set; }

        public LessonDetailVm(Lesson lesson)
        {
            Title = lesson.Title;
            LessonNo = lesson.LessonNo;
            VideoContentType = $"video/{lesson.Video.FileType}";
            Module = new LessonDetailVm_Module
            {
                Identifier = lesson.Module.Identifier,
                Title = lesson.Module.Title,
            };
            Product = new LessonDetailVm_Product
            {
                Identifier = lesson.Module.Product.Identifier,
                Title = lesson.Module.Product.Title,
            };
        }
    }
}
