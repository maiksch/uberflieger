using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Vms
{
    public class ProductListVm
    {
        public string Identifier { get; set; }
        public string Title { get; set; }

        public static List<ProductListVm> FromProducts(ICollection<Product> products)
        {

            var p = products.Select(data =>
                new ProductListVm
                {
                    Identifier = data.Identifier,
                    Title = data.Title,
                })
                .ToList();

            return p;
        }

    }
}
