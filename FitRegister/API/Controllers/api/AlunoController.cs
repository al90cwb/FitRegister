using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public AlunoController(AppDataContext context)
        {
            _context = context;
        }

        // Cadastrar Aluno
        [HttpPut("cadastrar")]
        public IActionResult Cadastrar([FromBody] Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest("Aluno não pode ser nulo.");
            }

            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar), new { id = aluno.Id }, aluno);
        }

        // Listar Alunos
        [HttpGet("listar")]
        public ActionResult<List<Aluno>> Listar()
        {
            return Ok(_context.Alunos.ToList());
        }

        // Buscar Aluno por ID
        [HttpPost("buscar")]
        public ActionResult<Aluno> Buscar([FromBody] string id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        // Remover Aluno
        [HttpDelete("remover")]
        public IActionResult Remover([FromBody] string id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return NoContent();
        }

        // Alterar Aluno
        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] AlunoUpdateDTO alunoDto)
        {
            if (alunoDto == null || string.IsNullOrEmpty(alunoDto.Id))
            {
                return BadRequest("Aluno ou ID não pode ser nulo.");
            }

            var alunoBuscado = _context.Alunos.Find(alunoDto.Id);
            if (alunoBuscado == null)
            {
                return NotFound();
            }

            // Atualiza apenas o que não é nulo
            if (!string.IsNullOrEmpty(alunoDto.Nome))
                alunoBuscado.Nome = alunoDto.Nome;

            if (!string.IsNullOrEmpty(alunoDto.Endereco))
                alunoBuscado.Endereco = alunoDto.Endereco;

            if (!string.IsNullOrEmpty(alunoDto.Telefone))
                alunoBuscado.Telefone = alunoDto.Telefone;

            if (!string.IsNullOrEmpty(alunoDto.Login))
                alunoBuscado.Login = alunoDto.Login;

            if (!string.IsNullOrEmpty(alunoDto.Senha))
                alunoBuscado.Senha = alunoDto.Senha;

            if (alunoDto.DataDuracao.HasValue)
                alunoBuscado.DataDuracao = alunoDto.DataDuracao.Value;

            _context.SaveChanges();
            return Ok(alunoBuscado);
        }

    }
}
