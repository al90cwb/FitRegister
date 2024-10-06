using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ProfessorController(AppDataContext context)
        {
            _context = context;
        }

        // Cadastrar Professor
        [HttpPut("cadastrar")]
        public IActionResult Cadastrar([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Professor não pode ser nulo.");
            }

            _context.Professores.Add(professor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar), new { id = professor.Id }, professor);
        }

        // Listar Professores
        [HttpGet("listar")]
        public ActionResult<List<Professor>> Listar()
        {
            return Ok(_context.Professores.ToList());
        }

        // Buscar Professor por ID
        [HttpPost("buscar")]
        public ActionResult<Professor> Buscar([FromBody] string id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound(new { Message = "Professor não encontrado" });
            }
            return Ok(professor);
        }

        // Remover Professor
        [HttpDelete("remover")]
        public IActionResult Remover([FromBody] string id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professores.Remove(professor);
            _context.SaveChanges();
            return NoContent();
        }

        // Alterar Professor
        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] ProfessorUpdateDTO professor)
        {
            Professor? professorbusca = _context.Professores.FirstOrDefault(p => p.Id == professor.Id);

            if (professorbusca == null)
            {
                return NotFound(new { Message = "Professor não encontrado" });
            }

            // Alterar os campos que forem não nulos (parcial)
            if (!string.IsNullOrEmpty(professor.Nome))
            {
                professorbusca.Nome = professor.Nome;
            }

            if (!string.IsNullOrEmpty(professor.Endereco))
            {
                professorbusca.Endereco = professor.Endereco;
            }

            if (!string.IsNullOrEmpty(professor.Telefone))
            {
                professorbusca.Telefone = professor.Telefone;
            }

            if (!string.IsNullOrEmpty(professor.Login))
            {
                professorbusca.Login = professor.Login;
            }

            if (!string.IsNullOrEmpty(professor.Senha))
            {
                professorbusca.Senha = professor.Senha;
            }

            // Salva as alterações no banco de dados
            _context.Professores.Update(professorbusca);
            _context.SaveChanges();

            return Ok(professorbusca);
        }


    }
}
