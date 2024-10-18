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

        [HttpPut("cadastrar")]
        public IActionResult Cadastrar([FromBody] UsuarioUpdt aluno, [FromQuery] string idPlano,string idTreino, string idProfessor)
        {
            if (string.IsNullOrEmpty(aluno.Endereco))
            {
                return BadRequest("Endereço não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(aluno.Login))
            {
                return BadRequest("Login não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(aluno.Nome))
            {
                return BadRequest("Nome não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(aluno.Senha))
            {
                return BadRequest("Senha não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(aluno.Telefone))
            {
                return BadRequest("Telefone não pode ser nulo.");
            }
            


            var plano = _context.Planos.FirstOrDefault(p => p.Id.Equals (idPlano));
            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }
            

            var treino = _context.Treinos.FirstOrDefault(p => p.Id.Equals (idTreino));
            if (treino == null)
            {
                return NotFound("Treino não encontrado.");
            }
           
            
            var professor = _context.Professores.FirstOrDefault(p => p.Id.Equals (idProfessor));
            if (professor == null)
            {
                return NotFound("Professor não encontrado.");
            }
            

            Aluno alunoNovo = new Aluno(aluno.Nome, aluno.Endereco,aluno.Telefone,aluno.Login,aluno.Senha);

            

            
            alunoNovo.Professor = professor;
            //alunoNovo.Plano = plano;
            //alunoNovo.Treino = treino;
            professor.Alunos.Add(alunoNovo);

            return Ok(professor);

            // professor.Alunos.Add(alunoNovo);
            // Ok(plano);
            // Ok(alunoNovo);

            // plano.Alunos.Add(alunoNovo);
            // Ok(plano);
            // Ok(alunoNovo);

            // treino.Alunos.Add(alunoNovo);
            // Ok(plano);
            // Ok(alunoNovo);

            
            //Ok(alunoNovo);

            //_context.Alunos.Add(aluno);
            //_context.SaveChanges();
            
            // return Ok();
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
        [HttpPut("alterarDadosAluno")]
        public IActionResult Alterar([FromBody] UsuarioUpdt alunoDto)
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

            _context.SaveChanges();
            return Ok(alunoBuscado);
        }

    }
}
