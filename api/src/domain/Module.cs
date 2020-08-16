using System.Collections.Generic;

namespace Domain
{
    public class Module
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }

        public Product Product { get; set; }
        public List<Lesson> Lessons { get; private set; }
    }
}
