using System.Collections.Generic;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Module> Modules { get; private set; }

        public Product()
        {
            Modules = new HashSet<Module>();
        }
    }
}
