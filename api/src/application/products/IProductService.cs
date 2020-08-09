using Application.Products.GetOne;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IProductService
    {
        Task<GetOneProductResponse> GetOne(string identifier);
    }
}
