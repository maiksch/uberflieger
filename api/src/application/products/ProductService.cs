using Application.Products.GetOne;
using Domain;
using System.Threading.Tasks;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        public Task<GetOneProductResponse> GetOne(string identifier)
        {
            var product = new Product
            {
                Id = 1,
                Identifier = identifier,
                Title = "Outcome-based Leadership",
                Description = "Im Outcome-based Leadership Programm lernst du, wie du nachhaltig Führungskompetenzen aufbaust und dich Schritt-für-Schritt zu einer erfolgreichen Führungskraft entwickelst. Dies ist ein \"Umsetzungsprogramm\", das dir dabei hilft, erstklassige Ergebnisse zu erzielen.",
            };

            var result = GetOneProductResponse.FromProduct(product);

            return Task.FromResult(result);
        }
    }
}
