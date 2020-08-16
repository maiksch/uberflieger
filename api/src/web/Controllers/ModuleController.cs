using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Modules;
using Application.Modules.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet("{identifier}")]
        public async Task<GetOneModuleResponse> Get(string identifier)
        {
            return await _moduleService.GetOne(identifier);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModuleController>/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
