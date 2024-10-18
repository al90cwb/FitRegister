using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase 
    {
        private readonly AppDataContext ctx;
        public AlunoController(AppDataContext context)
        {
            ctx = context;
        }

        // GET: /api/aluno/listar
        [HttpGet("listar")]
        public  async Task<IActionResult> Listar()
        {
            var alunos = await ctx.Alunos
            .ToListAsync();
            if (ctx.Alunos.Any())
            {
                return Ok(ctx.Alunos.ToList());
            }
            return NotFound("Nenhum aluno encontrado.");
        }

        // POST: api/aluno/cadastrar
        [HttpPost("cadastrar")]
        public IActionResult CadastrarAluno([FromBody] Aluno aluno)
        {   
            
            Aluno alunoNovo = new Aluno(aluno.Nome,aluno.Endereco,aluno.Telefone,aluno.Email,aluno.Senha,aluno.PlanoId);

            ctx.Alunos.Add(alunoNovo);
            ctx.SaveChanges();

            return Ok(aluno);
        }

         // GET: api/aluno/buscar/{id}
        [HttpGet("buscar")]
        public IActionResult BuscarAluno([FromRoute]string id)
        {
            var aluno = ctx.Alunos
                .Include(a => a.Plano)
                .FirstOrDefault(a => a.Id.Equals(id));

            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

          return Ok(aluno);
        }

        // DELETE: api/aluno/{id}
        [HttpDelete("deletar/{id}")]
        public IActionResult DeleteAluno(string id)
        {   
            
            var aluno = ctx.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound("Não existe um aluno com esse Id.");
            }

            ctx.Alunos.Remove(aluno);
            ctx.SaveChanges();

            return Ok("Aluno Deletado com sucesso.");
        }


        // PUT: api/aluno/alterar
        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] Aluno alunoUpdt)
        {
            Aluno? aluno = ctx.Alunos.FirstOrDefault(a => a.Id.Equals(alunoUpdt.Id));

            if (aluno == null)
            {
                return NotFound(new { Message = "Professor não encontrado" });
            }

            // Alterar os campos que forem não nulos (parcial)
            if (!string.IsNullOrEmpty(alunoUpdt.Nome))
            {
                aluno.Nome = alunoUpdt.Nome;
            }

            if (!string.IsNullOrEmpty(alunoUpdt.Endereco))
            {
                aluno.Endereco = alunoUpdt.Endereco;
            }

            if (!string.IsNullOrEmpty(alunoUpdt.Telefone))
            {
                aluno.Telefone = alunoUpdt.Telefone;
            }

            if (!string.IsNullOrEmpty(alunoUpdt.Email))
            {
                aluno.Email = alunoUpdt.Email;
            }

            if (!string.IsNullOrEmpty(alunoUpdt.Senha))
            {
                aluno.Senha = alunoUpdt.Senha;
            }

            ctx.Alunos.Update(aluno);
            ctx.SaveChanges();

            return Ok(aluno);
        }

    }
}
