namespace Domain
{
    public class Lesson
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int VideoId { get; set; }
        public int LessonNo { get; set; }
        public string Title { get; set; }

        public Module Module { get; set; }
        public Video Video { get; set; }
    }
}
