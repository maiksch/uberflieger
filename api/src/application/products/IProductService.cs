using Application.Products.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IProductService
    {
        Task<GetOneProductResponse> GetOne(string identifier);
        Task<List<GetManyProductsResponse>> GetMany();
    }
}
