using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
          private readonly AppDataContext _context;

        public PlanoController(AppDataContext context)
        {
            _context = context;
        }

        // Cadastrar Plano
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Plano plano)
        {
            if (plano == null)
            {
                return BadRequest("Plano não pode ser nulo.");
            }

            _context.Planos.Add(plano);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar), new { id = plano.Id }, plano);
        }

        // Listar Planos
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var planos = _context.Planos.ToList();
            return Ok(planos);
        }

        // Buscar Plano por ID
        [HttpGet("buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var plano = _context.Planos.Find(id);
            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }
            return Ok(plano);
        }

        // Remover Plano
        [HttpDelete("remover/{id}")]
        public IActionResult Remover(int id)
        {
            var plano = _context.Planos.Find(id);
            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }

            _context.Planos.Remove(plano);
            _context.SaveChanges();
            return NoContent();
        }

        // Alterar Plano
        [HttpPut("alterar/{id}")]
        public IActionResult Alterar(int id, [FromBody] Plano planoAlterado)
        {
            var planoExistente = _context.Planos.Find(id);
            if (planoExistente == null)
            {
                return NotFound("Plano não encontrado.");
            }

            // Atualiza as propriedades do plano
            planoExistente.NomePlano = planoAlterado.NomePlano;
            planoExistente.Valor = planoAlterado.Valor;

            _context.SaveChanges();
            return Ok(planoExistente);
        }
    }
}
