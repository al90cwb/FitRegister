using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinoController : ControllerBase
    {
        private readonly AppDataContext ctx;

        public TreinoController(AppDataContext context)
        {
            ctx = context;
        }

        //GET: /api/treinos/listar
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            if (ctx.Treinos.Any())
            {
                return Ok(ctx.Treinos.ToList());
            }
            return NotFound("Nenhum treino encontrado!");
        }

        //GET: /api/exercicios/buscar/{id}
        [HttpGet("buscarPorId/{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var treino = ctx.Treinos
                .Include(t => t.Exercicios)
                .ThenInclude(e => e.Treinos)
                .FirstOrDefault(t => t.Id.Equals(id));

            if (treino == null)
            {
                return NotFound($"Nenhum treino encontrado com o ID '{id}'.");
            }

            return Ok(treino);
        }

        //GET: /api/treinos/buscar/nome
        [HttpGet("buscarPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var treino = ctx.Treinos
                .Include(t => t.Exercicios)
                .ThenInclude(e => e.Treinos)
                .FirstOrDefault(t => t.Nome.Equals(nome));

            if (treino == null)
            {
                return NotFound($"Nenhum exercício encontrado com o nome '{nome}'.");
            }
            return Ok(treino);
        }

        //POST: api/treinos/cadastrar
        [HttpPost("cadastrar")]
        public async Task<IActionResult> PostTreino([FromBody] Treino treino)
        {
            if (treino == null)
            {
                return BadRequest("Treino não pode ser nulo.");
            }

            if (treino.Exercicios != null && treino.Exercicios.Count > 0)
            {
                var exercicios = await ctx.Exercicios
                    .Where(e => treino.Exercicios.Select(ex => ex.Id).Contains(e.Id))
                    .ToListAsync();
                treino.Exercicios = exercicios;
            }

            ctx.Treinos.Add(treino);
            await ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarPorId), new { id = treino.Id }, treino);
        }

        // DELETE: api/treinos/deletar/{id}
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(Guid id)
        {
            var treinos = ctx.Treinos.Find(id);
            if (treinos == null)
            {
                return NotFound($"Nenhum treino encontrado com o ID '{id}'.");
            }

            ctx.Treinos.Remove(treinos);
            ctx.SaveChanges();
            return NoContent();
        }

        private bool TreinoExists(Guid id)
        {
            return ctx.Treinos.Any(e => e.Id == id);
        }

        // PUT: api/treinos/alterar/{id}
        [HttpPut("alterar/{id}")]
        public IActionResult AlterarTreino(Guid id, [FromBody] Treino treinoAlterado)
        {
            var treinoExistente = ctx.Treinos
                .Include(t => t.Exercicios)
                .FirstOrDefault(t => t.Id == id);

            if (treinoExistente == null)
            {
                return NotFound($"Nenhum treino encontrado com o ID '{id}'.");
            }

            treinoExistente.Nome = treinoAlterado.Nome;
            treinoExistente.Finalidade = treinoAlterado.Finalidade;
            treinoExistente.Descricao = treinoAlterado.Descricao;
            treinoExistente.NivelTreino = treinoAlterado.NivelTreino;

            treinoExistente.Exercicios.Clear();
            foreach (var exercicio in treinoAlterado.Exercicios)
            {
                var exercicioExistente = ctx.Exercicios.Find(exercicio.Id);
                if (exercicioExistente != null)
                {
                    treinoExistente.Exercicios.Add(exercicioExistente);
                }
            }

            ctx.SaveChanges();

            return Ok(treinoExistente);
        }

        //Adicionar Exercicio no treino

        //Remover Exercicio no treino

    }
}