using Application.Products.Response;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
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
            var product = await _context.Products
                .Where(p => p.Identifier == identifier)
                .Include(p => p.Modules)
                .SingleOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            var result = GetOneProductResponse.FromProduct(product);

            return result;
        }

        public async Task<List<GetManyProductsResponse>> GetMany()
        {
            var products = await _context.Products.ToListAsync();

            return GetManyProductsResponse.FromProducts(products);
        }
    }
}
