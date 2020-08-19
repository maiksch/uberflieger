using Application.Products.Vms;
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

        public async Task<ProductDetailVm> GetOne(string identifier)
        {
            var product = await _context.Products
                .Where(p => p.Identifier == identifier)
                .Include(p => p.Modules)
                .SingleOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            var result = new ProductDetailVm(product);

            return result;
        }

        public async Task<List<ProductListVm>> GetMany()
        {
            var products = await _context.Products.ToListAsync();

            return ProductListVm.FromProducts(products);
        }
    }
}
