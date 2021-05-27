using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //com ele não precisa informar o "frombody" em uma action, por exemplo
    public class AlunoController : Controller
    {
        public AlunoController()
        {
            
        }

        public IActionResult Get()
        {
            return Ok();
        }

        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}