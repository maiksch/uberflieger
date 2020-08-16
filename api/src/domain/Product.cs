using System.Collections.Generic;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Module> Modules { get; private set; }
    }
}
