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
        [HttpPut("cadastrar")]
        public IActionResult Cadastrar([FromBody] Plano plano)
        {
            if (plano == null)
            {
                return BadRequest("Plano não pode ser nulo.");
            }

            Plano planoNovo = new Plano(plano.NomePlano,plano.Valor);

            _context.Planos.Add(planoNovo);
            _context.SaveChanges();
            return Ok(planoNovo);
        }

        // Listar Planos
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var planos = _context.Planos.ToList();
            return Ok(planos);
        }

        // Buscar Plano por ID
        [HttpGet("buscar")]
        public IActionResult Buscar([FromBody] string id)
        {
            var plano = _context.Planos.Find(id);
            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }
            return Ok(plano);
        }

        // Remover Plano
        [HttpDelete("remover")]
        public IActionResult Remover([FromBody] string id)
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
        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] Plano planoAlterado)
        {
            var planoExistente = _context.Planos.Find(planoAlterado.Id);
            if (planoExistente == null)
            {
                return NotFound("Plano não encontrado.");
            }

            if( planoAlterado.NomePlano!=null){
                planoExistente.NomePlano = planoAlterado.NomePlano;
            }
            if(planoAlterado.Valor!=null){
                planoExistente.Valor = planoAlterado.Valor;
            }

            _context.SaveChanges();
            return Ok(planoExistente);
        }
    }
}
