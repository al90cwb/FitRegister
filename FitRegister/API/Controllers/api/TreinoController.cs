using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public TreinoController(AppDataContext context)
        {
            _context = context;
        }

        // Cadastrar Treino
        [HttpPut("cadastrar")]
        public IActionResult Cadastrar([FromBody] Treino treino)
        {
            if (treino == null)
            {
                return BadRequest("Treino não pode ser nulo.");
            }

            _context.Treinos.Add(treino);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar), new { id = treino.Id }, treino);
        }

        // Listar Treinos
        [HttpGet("listar")]
        public ActionResult<List<Treino>> Listar()
        {
            return Ok(_context.Treinos.ToList());
        }

        // Buscar Treino por ID
        [HttpPost("buscar")]
        public ActionResult<Treino> Buscar([FromBody] int id)
        {
            var treino = _context.Treinos.Find(id);
            if (treino == null)
            {
                return NotFound();
            }
            return Ok(treino);
        }

        // Remover Treino
        [HttpDelete("remover")]
        public IActionResult Remover([FromBody] int id)
        {
            var treino = _context.Treinos.Find(id);
            if (treino == null)
            {
                return NotFound();
            }

            _context.Treinos.Remove(treino);
            _context.SaveChanges();
            return NoContent();
        }

        // Alterar Treino
        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] Treino treinoAtualizado)
        {
            var treino = _context.Treinos.Find(treinoAtualizado.Id);
            if (treino == null)
            {
                return NotFound();
            }

            treino.Descricao = treinoAtualizado.Descricao;
            treino.DuracaoEmDias = treinoAtualizado.DuracaoEmDias;

            _context.SaveChanges();
            return Ok(treino);
        }
    }
}
