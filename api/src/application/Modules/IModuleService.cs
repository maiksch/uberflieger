using Application.Modules.Responses;
using System.Threading.Tasks;

namespace Application.Modules
{
    public interface IModuleService
    {
        Task<GetOneModuleResponse> GetOne(string identifier);
    }
}
