using System;
using API.Models;

namespace API.Service;

public class UsuarioService
{
    private readonly AppDataContext _context;
    private readonly IUsuarioFactory _usuarioFactory;

    public UsuarioService(AppDataContext context, IUsuarioFactory usuarioFactory)
    {
        _context = context;
        _usuarioFactory = usuarioFactory;
    }

    // Adicionar Aluno
    public void AdicionarAluno(string nome, string endereco, string telefone, string login, string senha, PlanoDeUso plano, Professor professor)
    {
        var aluno = _usuarioFactory.CreateAluno(nome, endereco, telefone, login, senha, plano, professor);
        _context.Alunos.Add(aluno);
        _context.SaveChanges();
    }

    // Adicionar Professor
    public void AdicionarProfessor(string nome, string endereco, string telefone, string login, string senha)
    {
        var professor = _usuarioFactory.CreateProfessor(nome, endereco, telefone, login, senha);
        _context.Professores.Add(professor);
        _context.SaveChanges();
    }

    // Alterar Aluno
    public void AlterarAluno(int id, string nome, string endereco, string telefone, string login, string senha)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno != null)
        {
            aluno.Nome = nome ?? aluno.Nome;
            aluno.Endereco = endereco ?? aluno.Endereco;
            aluno.Telefone = telefone ?? aluno.Telefone;
            aluno.Login = login ?? aluno.Login;
            aluno.Senha = senha ?? aluno.Senha;
            _context.SaveChanges();
        }
    }

    // Alterar Professor
    public void AlterarProfessor(int id, string nome, string endereco, string telefone, string login, string senha)
    {
        var professor = _context.Professores.Find(id);
        if (professor != null)
        {
            professor.Nome = nome ?? professor.Nome;
            professor.Endereco = endereco ?? professor.Endereco;
            professor.Telefone = telefone ?? professor.Telefone;
            professor.Login = login ?? professor.Login;
            professor.Senha = senha ?? professor.Senha;
            _context.SaveChanges();
        }
    }

    // Remover Aluno
    public void RemoverAluno(int id)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno != null)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }
    }

    // Remover Professor
    public void RemoverProfessor(int id)
    {
        var professor = _context.Professores.Find(id);
        if (professor != null)
        {
            _context.Professores.Remove(professor);
            _context.SaveChanges();
        }
    }

    // Buscar Aluno
    public Aluno BuscarAlunoPorId(int id)
    {
        return _context.Alunos.Find(id);
    }

    // Buscar Professor
    public Professor BuscarProfessorPorId(int id)
    {
        return _context.Professores.Find(id);
    }

    // Listar Alunos
    public List<Aluno> ListarAlunos()
    {
        return _context.Alunos.ToList();
    }

    // Listar Professores
    public List<Professor> ListarProfessores()
    {
        return _context.Professores.ToList();
    }
}
