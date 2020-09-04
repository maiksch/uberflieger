using Application.Products.Vms;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        private readonly UberfliegerContext _context;
        private readonly IConfiguration _configuration;

        public ProductService(UberfliegerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ProductDetailVm> GetOne(string identifier)
        {
            var product = await _context.Products
                .Where(p => p.Identifier == identifier)
                .Include(p => p.Modules)
                .Include(p => p.Thumbnail)
                .SingleOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            var storageConnectionString = _configuration.GetConnectionString("Storage");
            var blobContainer = new BlobContainerClient(storageConnectionString, "thumbnails");
            var blob = blobContainer.GetBlobClient($"{product.Thumbnail.StorageId}.{product.Thumbnail.FileType}");

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
