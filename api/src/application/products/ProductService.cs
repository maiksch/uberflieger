using Application.Products.GetOne;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        private readonly UberfliegerContext _context;

        public ProductService(UberfliegerContext context)
        {
            _context = context;
        }

        public async Task<GetOneProductResponse> GetOne(string identifier)
        {
            var product = await _context.Products.Where(p => p.Identifier == identifier).SingleOrDefaultAsync();
            if (product == null)
            {
                return null;
            }

            var result = GetOneProductResponse.FromProduct(product);

            return result;
        }
    }
}
