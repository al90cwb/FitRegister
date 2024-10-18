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

         // PUT: api/exercicio/cadastrar
        [HttpPut("cadastrar")]
        public IActionResult Cadastrar([FromBody] Exercicio exercicio)
        {
            if (exercicio == null)
            {
                return BadRequest("Exercício não pode ser nulo.");
            }

            ctx.Exercicios.Add(exercicio);
            ctx.SaveChanges();
            return Ok(exercicio);
        }

        // Listar Exercicios
        [HttpGet("listar")]
        public ActionResult<List<Exercicio>> Listar()
        {
            return Ok(ctx.Exercicios.ToList());
        }

        // Buscar Exercicio por ID
        [HttpPost("buscar")]
        public ActionResult<Exercicio> Buscar([FromBody] Guid id)
        {
            var exercicio = ctx.Exercicios.Find(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            return Ok(exercicio);
        }

        // Remover Exercicio
        [HttpDelete("remover")]
        public IActionResult Remover([FromBody] Guid id)
        {
            var exercicio = ctx.Exercicios.Find(id);
            if (exercicio == null)
            {
                return NotFound();
            }

            ctx.Exercicios.Remove(exercicio);
            ctx.SaveChanges();
            return NoContent();
        }

        // PUT: api/exercicio/atualizar
        [HttpPut("atualizar")]
        public IActionResult Alterar([FromBody] Exercicio exercicioAtualizado)
        {
            var exercicio = ctx.Exercicios.Find(exercicioAtualizado.Id);
            if (exercicio == null)
            {
                return NotFound("Exercício não encontrado.");
            }

            // Atualizar os campos que foram fornecidos
            if (!string.IsNullOrEmpty(exercicioAtualizado.Nome))
            {
                exercicio.Nome = exercicioAtualizado.Nome;
            }

            if (!string.IsNullOrEmpty(exercicioAtualizado.GrupoMuscular))
            {
                exercicio.GrupoMuscular = exercicioAtualizado.GrupoMuscular;
            }

            if (!string.IsNullOrEmpty(exercicioAtualizado.Descricao))
            {
                exercicio.Descricao = exercicioAtualizado.Descricao;
            }

            if (exercicioAtualizado.Repeticoes > 0)
            {
                exercicio.Repeticoes = exercicioAtualizado.Repeticoes;
            }

            if (exercicioAtualizado.TempoDescanso > 0)
            {
                exercicio.TempoDescanso = exercicioAtualizado.TempoDescanso;
            }

            ctx.Exercicios.Update(exercicio);
            ctx.SaveChanges();

            return Ok(exercicio);
        }
    }
}
