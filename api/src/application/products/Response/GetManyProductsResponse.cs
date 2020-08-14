using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Response
{

    public class GetManyProductsResponse
    {
        public string Identifier { get; set; }
        public string Title { get; set; }

        public static List<GetManyProductsResponse> FromProducts(ICollection<Product> products)
        {

            var p = products.Select(data =>
                new GetManyProductsResponse
                {
                    Identifier = data.Identifier,
                    Title = data.Title,
                })
                .ToList();

            return p;
        }
    }
}
