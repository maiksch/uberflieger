using Application.Modules.Vms;
using System.Threading.Tasks;

namespace Application.Modules
{
    public interface IModuleService
    {
        Task<ModuleDetailVm> GetOne(string identifier);
    }
}
