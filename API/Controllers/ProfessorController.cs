using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly AppDataContext ctx;

        public ProfessorController(AppDataContext context)
        {
            ctx = context;
        }

        // POST: api/professor/cadastrar
        [HttpPost("cadastrar")]
        public IActionResult CadastrarProfessor([FromBody] Professor professor)
        {
            // Cria uma nova instância de Professor com os dados recebidos
            Professor professorNovo = new Professor(professor.Nome, professor.Endereco, professor.Telefone, professor.Email, professor.Senha);

            // Adiciona o novo professor ao contexto
            ctx.Professores.Add(professorNovo);
            ctx.SaveChanges();

            // Retorna o professor cadastrado
            return Ok(professorNovo);
        }

        // POST: api/professor/listar
        [HttpGet("listar")]
        public ActionResult<List<Professor>> Listar()
        {
            return Ok(ctx.Professores.ToList());
        }

        // POST: api/professor/buscar
        [HttpPost("buscar")]
        public ActionResult<Professor> Buscar([FromBody] Guid id)
        {
            var professor = ctx.Professores.FirstOrDefault(p => p.Id.Equals(id));
            if (professor == null)
            {
                return NotFound(new { Message = "Professor não encontrado" });
            }
            return Ok(professor);
        }

        // DELETE: api/professor/remover
        [HttpDelete("remover")]
        public IActionResult Remover([FromBody] Guid id)
        {
            var professor = ctx.Professores.FirstOrDefault(p => p.Id.Equals(id));
            if (professor == null)
            {
                return NotFound();
            }

            ctx.Professores.Remove(professor);
            ctx.SaveChanges();
            return NoContent();
        }

        // PUT: api/professor/alterar
        [HttpPut("alterar")]
        public IActionResult AlterarProfessor([FromBody] Professor professorUpdt)
        {
            var professor = ctx.Professores.FirstOrDefault(p => p.Id.Equals(professorUpdt.Id));

            if (professor == null)
            {
                return NotFound(new { Message = "Professor não encontrado" });
            }

            // Alterar os campos que forem não nulos (parcial)
            if (!string.IsNullOrEmpty(professorUpdt.Nome))
            {
                professor.Nome = professorUpdt.Nome;
            }

            if (!string.IsNullOrEmpty(professorUpdt.Endereco))
            {
                professor.Endereco = professorUpdt.Endereco;
            }

            if (!string.IsNullOrEmpty(professorUpdt.Telefone))
            {
                professor.Telefone = professorUpdt.Telefone;
            }

            if (!string.IsNullOrEmpty(professorUpdt.Email))
            {
                professor.Email = professorUpdt.Email;
            }

            if (!string.IsNullOrEmpty(professorUpdt.Senha))
            {
                professor.Senha = professorUpdt.Senha;
            }

            ctx.Professores.Update(professor);
            ctx.SaveChanges();

            return Ok(professor);
        }
    }
}
