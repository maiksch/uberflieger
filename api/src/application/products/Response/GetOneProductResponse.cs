using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Response
{
    public class GetOneProductModuleDetails
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
    }

    public class GetOneProductResponse
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<GetOneProductModuleDetails> Modules { get; set; }


        public static GetOneProductResponse FromProduct(Product product)
        {

            var modules = product.Modules.Select(data =>
                new GetOneProductModuleDetails
                {
                    Identifier = data.Identifier,
                    Title = data.Title,
                })
                .ToList();

            var result = new GetOneProductResponse
            {
                Identifier = product.Identifier,
                Title = product.Title,
                Description = product.Description,
                Modules = modules,
            };

            return result;
        }
    }
}
