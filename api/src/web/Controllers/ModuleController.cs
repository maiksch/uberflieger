using System.Threading.Tasks;
using Application.Lessons;
using Application.Modules;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        private readonly ILessonService _lessonService;

        public ModuleController(IModuleService moduleService, ILessonService lessonService)
        {
            _moduleService = moduleService;
            _lessonService = lessonService;
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> Get(string identifier)
        {
            var result = await _moduleService.GetOne(identifier);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{identifier}/lesson/{lessonNo:int}")]
        public async Task<IActionResult> GetLesson(string identifier, int lessonNo)
        {
            var result = await _lessonService.GetOne(identifier, lessonNo);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
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
