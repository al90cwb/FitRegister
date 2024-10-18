using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
            
           Treino treinoNovo = new Treino();
            treinoNovo.Nome = treino.Nome;
            treinoNovo.Descricao = treino.Descricao;
            treinoNovo.NivelTreino = treino.NivelTreino;
            treinoNovo.Finalidade = treino.Finalidade;
        

            _context.Treinos.Add(treinoNovo);
            _context.SaveChanges();
            return Ok(treinoNovo);
        }

        // Listar Treinos
        [HttpGet("listar")]
        public ActionResult<List<Treino>> Listar()
        {
            return Ok(_context.Treinos.ToList());
        }

        // Buscar Treino por ID
        [HttpPost("buscar")]
        public ActionResult<Treino> Buscar([FromBody] string id)
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
        public IActionResult Remover([FromBody] string id)
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
        
        // PUT: api/treino/alterar
        [HttpPut("alterar")]
        public IActionResult AlterarTreino([FromBody] Treino treinoUpdt)
        {
            var treino = _context.Treinos.FirstOrDefault(t => t.Id.Equals(treinoUpdt.Id));

            if (treino == null)
            {
                return NotFound(new { Message = "Treino não encontrado" });
            }

            // Alterar os campos que forem não nulos (parcial)
            if (!string.IsNullOrEmpty(treinoUpdt.Nome))
            {
                treino.Nome = treinoUpdt.Nome;
            }

            if (!string.IsNullOrEmpty(treinoUpdt.Finalidade))
            {
                treino.Finalidade = treinoUpdt.Finalidade;
            }

            if (!string.IsNullOrEmpty(treinoUpdt.Descricao))
            {
                treino.Descricao = treinoUpdt.Descricao;
            }

            if (!string.IsNullOrEmpty(treinoUpdt.NivelTreino))
            {
                treino.NivelTreino = treinoUpdt.NivelTreino;
            }

            _context.Treinos.Update(treino);
            _context.SaveChanges();

            return Ok(treino);
        }

        //Adicionar Exercicio no treino

        //Remover Exercicio no treino

    }
}
