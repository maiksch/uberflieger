using Application.Products.Vms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IProductService
    {
        Task<ProductDetailVm> GetOne(string identifier);
        Task<List<ProductListVm>> GetMany();
    }
}
