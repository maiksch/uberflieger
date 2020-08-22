using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Vms
{
    public class ModuleDetailVm
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
    }

    public class ProductDetailVm
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public List<ModuleDetailVm> Modules { get; set; }

        public ProductDetailVm(Product product, string thumbnailUri)
        {
            Identifier = product.Identifier;
            Title = product.Title;
            Description = product.Description;
            Thumbnail = thumbnailUri;
            Modules = product.Modules.Select(data =>
                new ModuleDetailVm
                {
                    Identifier = data.Identifier,
                    Title = data.Title,
                })
                .ToList();
        }
    }
}
