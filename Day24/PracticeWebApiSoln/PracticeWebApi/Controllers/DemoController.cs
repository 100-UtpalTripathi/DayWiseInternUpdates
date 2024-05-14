using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Hello World {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Hello World {value}");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Hello World {id} {value}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Hello World {id}");
        }
    }
}
