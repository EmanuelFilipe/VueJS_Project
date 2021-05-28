using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data.Interface;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //com ele não precisa informar o "frombody" em uma action, por exemplo
    public class AlunoController : Controller
    {
        private IRepository _repository;

        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllAlunosAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("ByProfessor/{professorId}")]
        public async Task<IActionResult> GetProfessorById(int professorId)
        {
            try
            {
                var result = await _repository.GetAlunosByProfessorIdAsync(professorId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlunoById(int id)
        {
            try
            {
                var result = await _repository.GetAlunoByIdAsync(id, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repository.Add(model);

                if(await _repository.SaveChangesAsync())
                    return Created($"/api/aluno/{model.Id}", model);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno model)
        {
            try
            {
                var aluno = await _repository.GetAlunoByIdAsync(id, false);
                
                if(aluno == null) return NotFound();

                 _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    aluno = await _repository.GetAlunoByIdAsync(id, true);
                    return Created($"/api/aluno/{model.Id}", aluno);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 var aluno = await _repository.GetAlunoByIdAsync(id, false);
                
                if(aluno == null) return NotFound();

                 _repository.Delete(aluno);

                if (await _repository.SaveChangesAsync())
                {
                    aluno = await _repository.GetAlunoByIdAsync(id, true);
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }
    }
}