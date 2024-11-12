using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly AppDataContext ctx;

        public ExercicioController(AppDataContext context)
        {
            ctx = context;
        }

        //POST: /api/exercicios/cadastrar/
        [HttpPost("cadastrar")]
        public IActionResult CadastrarExercicios([FromBody] Exercicio exercicios)
        {
            if (exercicios == null)
            {
                return BadRequest("Exercício não pode ser nulo.");
            }

            ctx.Exercicios.Add(exercicios);
            ctx.SaveChanges();
            return CreatedAtAction(nameof(CadastrarExercicios), new { id = exercicios.Id }, exercicios);
        }

        //POST: /api/exercicios/cadastrarlista/
        [HttpPost("cadastrarlista")]
        public IActionResult CadastrarLista([FromBody] List<Exercicio> exercicios)
        {
            if (exercicios == null || !exercicios.Any())
            {
                return BadRequest("Lista de exercícios não pode ser nula");
            }
            ctx.Exercicios.AddRange(exercicios);
            ctx.SaveChanges();
            return Created("", exercicios);
        }

        //GET: /api/exercicios/listar
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            if (ctx.Exercicios.Any())
            {
                return Ok(ctx.Exercicios.ToList());
            }
            return NotFound("Nenhum exercício encontrado!");
        }

        //GET: /api/exercicios/buscar/{id}
        [HttpGet("buscarPorId/{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            Exercicio? exercicios = ctx.Exercicios.Find(id);
            if (exercicios == null)
            {
                return NotFound($"Nenhum exercício encontrado com o ID '{id}'.");
            }
            return Ok(exercicios);
        }

        //GET: /api/exercicios/buscar/nome
        [HttpGet("buscarPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            List<Exercicio> exercicios = ctx.Exercicios.Where(x => x.Nome.Contains(nome)).ToList();

            if (!exercicios.Any())
            {
                return NotFound($"Nenhum exercício encontrado com o nome '{nome}'.");
            }
            return Ok(exercicios);
        }

        //DELETE: /api/exercicios/deletar/{id}
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(Guid id)
        {
            var exercicios = ctx.Exercicios.Find(id);
            if (exercicios == null)
            {
                return NotFound($"Nenhum exercício encontrado com o ID '{id}'.");
            }

            ctx.Exercicios.Remove(exercicios);
            ctx.SaveChanges();
            return NoContent();
        }

        //PUT: /api/exercicios/alterar/{id}
        [HttpPut("alterar/{id}")]
        public IActionResult Alterar(Guid id, [FromBody] Exercicio exercicioAlterado)
        {
            var exercicios = ctx.Exercicios.Find(id);
            if (exercicios == null)
            {
                return NotFound($"Nenhum exercício encontrado com o ID '{id}'.");
            }

            exercicios.Nome = exercicioAlterado.Nome;
            exercicios.GrupoMuscular = exercicioAlterado.GrupoMuscular;
            exercicios.Descricao = exercicioAlterado.Descricao;
            exercicios.Repeticoes = exercicioAlterado.Repeticoes;
            exercicios.TempoDescanso = exercicioAlterado.TempoDescanso;

            ctx.SaveChanges();
            return Ok(exercicios);
        }
    }
}
