namespace Domain
{
    public class Lesson
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }

        public Module Module { get; set; }
    }
}
