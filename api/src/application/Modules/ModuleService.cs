using Application.Modules.Vms;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Modules
{
    public class ModuleService : IModuleService
    {
        private readonly UberfliegerContext _context;

        public ModuleService(UberfliegerContext context)
        {
            _context = context;
        }

        public async Task<ModuleDetailVm> GetOne(string identifier)
        {
            var module = await _context.Modules.Where(m => m.Identifier == identifier)
                                               .Include(m => m.Lessons)
                                               .SingleAsync();
            return new ModuleDetailVm(module);
        }
    }
}
