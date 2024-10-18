using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {   
        private readonly AppDataContext ctx;
        public PlanoController(AppDataContext context)
        {
            ctx = context;
        }

        //POSt: /api/plano/cadastrar
        [HttpPost("cadastrar")]
        public IActionResult CadastrarPlano([FromBody] Plano plano)
        {   
            if(plano == null)
            {
                return BadRequest("Erro");
            }

            var planoExistente = ctx.Planos.FirstOrDefault(p => p.NomePlano.ToLower() == plano.NomePlano.ToLower());
            if(planoExistente != null)
            {
                return BadRequest("Já existe um plano com esse nome, por favor, faça as alterações necessárias para concluir o processo.");
            }
            
            ctx.Planos.Add(plano);
            ctx.SaveChanges();
            return CreatedAtAction(nameof(CadastrarPlano), new {id = plano.Id}, plano);
        }

        //PUT: /api/plano/atualizar
        [HttpPut("atualizar/{id}")]
        public  IActionResult AtualizarPlano(Guid id, [FromBody] Plano planoAlterado)
        {
            var plano =  ctx.Planos.Find(id);

            if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); 
                }

            if(plano == null)
            {
                return NotFound("Insira um ID valido.");
            }

            plano.NomePlano = planoAlterado.NomePlano;
            plano.Valor = planoAlterado.Valor;

            var planoExistente = ctx.Planos.FirstOrDefault(p => p.NomePlano.ToLower() == plano.NomePlano.ToLower());
            if(planoExistente != null && planoExistente.Id != plano.Id)
            {
                return BadRequest("Já existe um plano com esse nome, por favor, faça as alterações necessárias para concluir o processo.");
            }

            ctx.SaveChanges();
            return Ok(plano);
        }

        //DELETE: /api/plano/deletar
        [HttpDelete("deletar/{id}")]
        public  IActionResult DeletarPlano(Guid id)
        {
            var plano =  ctx.Planos.Include(p => p.Alunos).FirstOrDefault(p => p.Id == id);
            if(plano == null)
            {
                return NotFound("Insira um ID valido.");
            }
            if(plano.Alunos.Any())
            {
                return BadRequest("Não é possivel deletar um plano que possui alunos registrado. Por favor, aloque os alunos para um novo plano antes de continuar.");
            }
            
            ctx.Planos.Remove(plano);
            ctx.SaveChanges();
            return Ok(plano);
        }

        //GET: /api/plano/buscar
        [HttpGet("buscar/{nome}")]
        public  IActionResult BuscarPlano(string nome)
        {
            var plano = ctx.Planos
            .Where(p => p.NomePlano.ToLower() == nome.ToLower())
            .Select(p => new
             {
                p.Id,
                p.Valor,
                NomePlano = p.NomePlano,
                Alunos = p.Alunos.Select(a => a.Nome).ToList()
            })
            .FirstOrDefault();
            
            if(plano == null)
            {
                return NotFound("Insira o nome de um plano valido.");
            }
            return Ok(plano);
        }   
        
        //PUT: /api/plano/mover-aluno/para-plano
        [HttpPut("mover-aluno/{id}/para-plano/{novoPlanoId}")]
        public IActionResult MoverAluno(Guid id, Guid novoPlanoId)
        {
            var aluno = ctx.Alunos.Include(a => a.Plano).FirstOrDefault(a => a.Id == id);
            if(aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            var novoPlano = ctx.Planos.FirstOrDefault(p => p.Id == novoPlanoId);
            if(novoPlano == null)
            {
                return NotFound("Plano não encontrado.");
            }

            aluno.PlanoId = novoPlano.Id;
            aluno.Plano = novoPlano;

            ctx.SaveChanges();
            return Ok($"Aluno {aluno.Nome} foi movido para o plano {novoPlano.NomePlano}");
        }

        //API: /api/planos/mover-alunos/
        [HttpPut("mover-alunos/{planoAntigoId}/{planoNovoId}")]
        public  IActionResult MoverAlunos(Guid planoAntigoId, Guid planoNovoId)
        {
            var planoAntigo = ctx.Planos.Include(p => p.Alunos).FirstOrDefault(p => p.Id == planoAntigoId);
            var planoNovo = ctx.Planos.Find(planoNovoId);

            if(planoAntigo == null)
            {
                return NotFound("Nenhum plano encontrado.");
            }

            if(planoNovo == null)
            {
                return NotFound("Não existe nenhum plano com esse ID.");
            }

            if(!planoAntigo.Alunos.Any())
            {
                return BadRequest($"Nenhum a alunos registrados no plano {planoAntigo}.");
            }

            var alunosParaMover = planoAntigo.Alunos.ToList();

            foreach (var aluno in planoAntigo.Alunos)
            {

                ctx.Entry(aluno).State = EntityState.Detached;

                aluno.PlanoId = planoNovo.Id;
                aluno.Plano = planoNovo;

                ctx.Alunos.Attach(aluno);
                ctx.Entry(aluno).State = EntityState.Modified;
            }

            ctx.SaveChanges();
            return Ok($"Todos os alunos foram movidos do plano '{planoAntigo.NomePlano}' para o plano '{planoNovo.NomePlano}'.");
        }

        //GET: /api/plano/listar
        [HttpGet("listar")]
        public  async Task<IActionResult> Listar()
        {
            var plano = await ctx.Planos
            .Include(p => p.Alunos)
            .ToListAsync();
            
            if (!ctx.Planos.Any())
            {
                return NotFound("Não a planos cadastrados.");
            }

            var resultado = plano.Select(p => new{
                PlanoId = p.Id,
                NomePlano = p.NomePlano,
                Alunos = p.Alunos.Select(p => p.Nome).ToList()
            }).ToList();

            return Ok(resultado);
        }
    }
    
}