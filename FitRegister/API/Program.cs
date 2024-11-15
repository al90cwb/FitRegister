using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options => 
    options.UseSqlite("Data Source=FitRegisterDb.db")); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

builder.Services.AddAuthorization();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");

// Requisições para aluno
app.MapGet("/api/aluno/listar", async (AppDataContext ctx) => 
{
    var alunos = await ctx.Alunos.ToListAsync();
    return alunos.Any() ? Results.Ok(alunos) : Results.NotFound("Nenhum aluno encontrado.");
});

app.MapPost("/api/aluno/cadastrar", async (AppDataContext ctx, Aluno aluno) => 
{
    var alunoNovo = new Aluno(aluno.Nome, aluno.Endereco, aluno.Telefone, aluno.Email, aluno.Senha, aluno.PlanoId);
    ctx.Alunos.Add(alunoNovo);
    await ctx.SaveChangesAsync();
    return Results.Ok(alunoNovo);
});

app.MapGet("/api/aluno/buscar/{id}", async (AppDataContext ctx, Guid id) => 
{
    var aluno = await ctx.Alunos.Include(a => a.Plano).FirstOrDefaultAsync(a => a.Id == id);
    return aluno is not null ? Results.Ok(aluno) : Results.NotFound("Aluno não encontrado.");
});

app.MapDelete("/api/aluno/deletar/{id}", async (AppDataContext ctx, Guid id) => 
{
    var aluno = await ctx.Alunos.FindAsync(id);
    if (aluno == null)
        return Results.NotFound("Não existe um aluno com esse Id.");
    
    ctx.Alunos.Remove(aluno);
    await ctx.SaveChangesAsync();
    return Results.Ok("Aluno deletado com sucesso.");
});

app.MapPut("/api/aluno/alterar", async (AppDataContext ctx, Aluno alunoUpdt) => 
{
    var aluno = await ctx.Alunos.FindAsync(alunoUpdt.Id);
    if (aluno == null)
        return Results.NotFound(new { Message = "Aluno não encontrado" });

    aluno.Nome = alunoUpdt.Nome ?? aluno.Nome;
    aluno.Endereco = alunoUpdt.Endereco ?? aluno.Endereco;
    aluno.Telefone = alunoUpdt.Telefone ?? aluno.Telefone;
    aluno.Email = alunoUpdt.Email ?? aluno.Email;
    aluno.Senha = alunoUpdt.Senha ?? aluno.Senha;

    ctx.Alunos.Update(aluno);
    await ctx.SaveChangesAsync();
    return Results.Ok(aluno);
});

//Requisições para professor
app.MapPost("/api/professor/cadastrar", async (AppDataContext ctx, Professor professor) => 
{
    var professorNovo = new Professor(professor.Nome, professor.Endereco, professor.Telefone, professor.Email, professor.Senha);
    ctx.Professores.Add(professorNovo);
    await ctx.SaveChangesAsync();
    return Results.Ok(professorNovo);
});

app.MapGet("/api/professor/listar", async (AppDataContext ctx) => 
{
    var professores = await ctx.Professores.ToListAsync();
    return Results.Ok(professores);
});

app.MapGet("/api/professor/buscar/{id}", async (AppDataContext ctx, Guid id) => 
{
    var professor = await ctx.Professores.FindAsync(id);
    return professor is not null ? Results.Ok(professor) : Results.NotFound(new { Message = "Professor não encontrado" });
});

app.MapDelete("/api/professor/remover/{id}", async (AppDataContext ctx, Guid id) => 
{
    var professor = await ctx.Professores.FindAsync(id);
    if (professor == null)
        return Results.NotFound();

    ctx.Professores.Remove(professor);
    await ctx.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPut("/api/professor/alterar", async (AppDataContext ctx, Professor professorUpdt) => 
{
    var professor = await ctx.Professores.FindAsync(professorUpdt.Id);
    if (professor == null)
        return Results.NotFound(new { Message = "Professor não encontrado" });

    professor.Nome = professorUpdt.Nome ?? professor.Nome;
    professor.Endereco = professorUpdt.Endereco ?? professor.Endereco;
    professor.Telefone = professorUpdt.Telefone ?? professor.Telefone;
    professor.Email = professorUpdt.Email ?? professor.Email;
    professor.Senha = professorUpdt.Senha ?? professor.Senha;

    ctx.Professores.Update(professor);
    await ctx.SaveChangesAsync();
    return Results.Ok(professor);
});

//Requisições para exercicios
app.MapPost("/api/exercicios/cadastrar", async (AppDataContext ctx, Exercicio exercicio) =>
{
    if (exercicio == null)
    {
        return Results.BadRequest("Exercício não pode ser nulo.");
    }

    ctx.Exercicios.Add(exercicio);
    await ctx.SaveChangesAsync();
    return Results.Created($"/api/exercicios/{exercicio.Id}", exercicio);
});

app.MapPost("/api/exercicios/cadastrarlista", async (AppDataContext ctx, List<Exercicio> exercicios) =>
{
    if (exercicios == null || !exercicios.Any())
    {
        return Results.BadRequest("Lista de exercícios não pode ser nula.");
    }

    ctx.Exercicios.AddRange(exercicios);
    await ctx.SaveChangesAsync();
    return Results.Created($"/api/exercicios/cadastrarlista", exercicios);
});

app.MapGet("/api/exercicios/listar", async (AppDataContext ctx) =>
{
    var exercicios = await ctx.Exercicios.ToListAsync();
    return exercicios.Any() ? Results.Ok(exercicios) : Results.NotFound("Nenhum exercício encontrado!");
});

app.MapGet("/api/exercicios/buscar/{id}", async (AppDataContext ctx, Guid id) =>
{
    var exercicio = await ctx.Exercicios.FindAsync(id);
    return exercicio is not null ? Results.Ok(exercicio) : Results.NotFound($"Nenhum exercício encontrado com o ID '{id}'.");
});

app.MapGet("/api/exercicios/buscarPorNome/{nome}", async (AppDataContext ctx, string nome) =>
{
    var exercicios = await ctx.Exercicios.Where(x => x.Nome.Contains(nome)).ToListAsync();
    return exercicios.Any() ? Results.Ok(exercicios) : Results.NotFound($"Nenhum exercício encontrado com o nome '{nome}'.");
});

app.MapDelete("/api/exercicios/deletar/{id}", async (AppDataContext ctx, Guid id) =>
{
    var exercicio = await ctx.Exercicios.FindAsync(id);
    if (exercicio == null)
    {
        return Results.NotFound($"Nenhum exercício encontrado com o ID '{id}'.");
    }

    ctx.Exercicios.Remove(exercicio);
    await ctx.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPut("/api/exercicios/alterar/{id}", async (AppDataContext ctx, Guid id, Exercicio exercicioAlterado) =>
{
    var exercicio = await ctx.Exercicios.FindAsync(id);
    if (exercicio == null)
    {
        return Results.NotFound($"Nenhum exercício encontrado com o ID '{id}'.");
    }

    exercicio.Nome = exercicioAlterado.Nome;
    exercicio.GrupoMuscular = exercicioAlterado.GrupoMuscular;
    exercicio.Descricao = exercicioAlterado.Descricao;
    exercicio.Repeticoes = exercicioAlterado.Repeticoes;
    exercicio.TempoDescanso = exercicioAlterado.TempoDescanso;

    await ctx.SaveChangesAsync();
    return Results.Ok(exercicio);
});

//Requisições para treino
app.MapGet("/api/treinos/listar", async (AppDataContext ctx) =>
{
    var treinos = await ctx.Treinos.ToListAsync();
    return treinos.Any() ? Results.Ok(treinos) : Results.NotFound("Nenhum treino encontrado!");
});

app.MapGet("/api/treinos/buscarPorId/{id}", async (AppDataContext ctx, Guid id) =>
{
    var treino = await ctx.Treinos
        .Include(t => t.Exercicios)
        .ThenInclude(e => e.Treinos)
        .FirstOrDefaultAsync(t => t.Id == id);

    return treino is not null ? Results.Ok(treino) : Results.NotFound($"Nenhum treino encontrado com o ID '{id}'.");
});

app.MapGet("/api/treinos/buscarPorNome/{nome}", async (AppDataContext ctx, string nome) =>
{
    var treino = await ctx.Treinos
        .Include(t => t.Exercicios)
        .ThenInclude(e => e.Treinos)
        .FirstOrDefaultAsync(t => t.Nome == nome);

    return treino is not null ? Results.Ok(treino) : Results.NotFound($"Nenhum treino encontrado com o nome '{nome}'.");
});

app.MapPost("/api/treinos/cadastrar", async (AppDataContext ctx, Treino treino) =>
{
    if (treino == null)
    {
        return Results.BadRequest("Treino não pode ser nulo.");
    }

    if (treino.Exercicios != null && treino.Exercicios.Any())
    {
        var exercicios = await ctx.Exercicios
            .Where(e => treino.Exercicios.Select(ex => ex.Id).Contains(e.Id))
            .ToListAsync();
        treino.Exercicios = exercicios;
    }

    ctx.Treinos.Add(treino);
    await ctx.SaveChangesAsync();

    return Results.Created($"/api/treinos/{treino.Id}", treino);
});

app.MapDelete("/api/treinos/deletar/{id}", async (AppDataContext ctx, Guid id) =>
{
    var treino = await ctx.Treinos.FindAsync(id);
    if (treino == null)
    {
        return Results.NotFound($"Nenhum treino encontrado com o ID '{id}'.");
    }

    ctx.Treinos.Remove(treino);
    await ctx.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPut("/api/treinos/alterar/{id}", async (AppDataContext ctx, Guid id, Treino treinoAlterado) =>
{
    var treinoExistente = await ctx.Treinos
        .Include(t => t.Exercicios)
        .FirstOrDefaultAsync(t => t.Id == id);

    if (treinoExistente == null)
    {
        return Results.NotFound($"Nenhum treino encontrado com o ID '{id}'.");
    }

    treinoExistente.Nome = treinoAlterado.Nome;
    treinoExistente.Finalidade = treinoAlterado.Finalidade;
    treinoExistente.Descricao = treinoAlterado.Descricao;
    treinoExistente.NivelTreino = treinoAlterado.NivelTreino;

    treinoExistente.Exercicios.Clear();
    foreach (var exercicio in treinoAlterado.Exercicios)
    {
        var exercicioExistente = await ctx.Exercicios.FindAsync(exercicio.Id);
        if (exercicioExistente != null)
        {
            treinoExistente.Exercicios.Add(exercicioExistente);
        }
    }

    await ctx.SaveChangesAsync();
    return Results.Ok(treinoExistente);
});

//Requisições para plano
app.MapPost("/api/plano/cadastrar", async (AppDataContext ctx, Plano plano) =>
{
    if (plano == null)
        return Results.BadRequest("Erro");

    var planoExistente = await ctx.Planos
        .FirstOrDefaultAsync(p => p.NomePlano.ToLower() == plano.NomePlano.ToLower());

    if (planoExistente != null)
        return Results.BadRequest("Já existe um plano com esse nome.");

    ctx.Planos.Add(plano);
    await ctx.SaveChangesAsync();
    return Results.Created($"/api/plano/{plano.Id}", plano);
});

app.MapPut("/api/plano/atualizar/{id}", async (AppDataContext ctx, Guid id, Plano planoAlterado) =>
{
    var plano = await ctx.Planos.FindAsync(id);

    if (plano == null)
        return Results.NotFound("Insira um ID valido.");

    if (await ctx.Planos.AnyAsync(p => p.NomePlano.ToLower() == planoAlterado.NomePlano.ToLower() && p.Id != plano.Id))
        return Results.BadRequest("Já existe um plano com esse nome.");

    plano.NomePlano = planoAlterado.NomePlano;
    plano.Valor = planoAlterado.Valor;
    plano.Parcelas = planoAlterado.Parcelas;

    await ctx.SaveChangesAsync();
    return Results.Ok(plano);
});

app.MapDelete("/api/plano/deletar/{id}", async (AppDataContext ctx, Guid id) =>
{
    var plano = await ctx.Planos.Include(p => p.Alunos).FirstOrDefaultAsync(p => p.Id == id);

    if (plano == null)
        return Results.NotFound("Insira um ID valido.");

    if (plano.Alunos.Any())
        return Results.BadRequest("Não é possível deletar um plano que possui alunos registrados.");

    ctx.Planos.Remove(plano);
    await ctx.SaveChangesAsync();
    return Results.Ok(plano);
});

app.MapGet("/api/plano/buscar/{nome}", async (AppDataContext ctx, string nome) =>
{
    var plano = await ctx.Planos
        .Where(p => p.NomePlano.ToLower() == nome.ToLower())
        .Include(p => p.Alunos)
        .FirstOrDefaultAsync();

    return plano != null ? Results.Ok(plano) : Results.NotFound("Insira o nome de um plano válido.");
});

app.MapPut("/api/plano/mover-aluno/{id}/para-plano/{novoPlanoId}", async (AppDataContext ctx, Guid id, Guid novoPlanoId) =>
{
    var aluno = await ctx.Alunos.Include(a => a.Plano).FirstOrDefaultAsync(a => a.Id == id);
    if (aluno == null)
        return Results.NotFound("Aluno não encontrado.");

    var novoPlano = await ctx.Planos.FindAsync(novoPlanoId);
    if (novoPlano == null)
        return Results.NotFound("Plano não encontrado.");

    aluno.PlanoId = novoPlano.Id;
    aluno.Plano = novoPlano;

    await ctx.SaveChangesAsync();
    return Results.Ok($"Aluno {aluno.Nome} foi movido para o plano {novoPlano.NomePlano}");
});

app.MapPut("/api/plano/mover-alunos/{planoAntigoId}/{planoNovoId}", async (AppDataContext ctx, Guid planoAntigoId, Guid planoNovoId) =>
{
    var planoAntigo = await ctx.Planos.Include(p => p.Alunos).FirstOrDefaultAsync(p => p.Id == planoAntigoId);
    var planoNovo = await ctx.Planos.FindAsync(planoNovoId);

    if (planoAntigo == null)
        return Results.NotFound("Nenhum plano encontrado.");
    if (planoNovo == null)
        return Results.NotFound("Não existe nenhum plano com esse ID.");
    if (!planoAntigo.Alunos.Any())
        return Results.BadRequest("Nenhum aluno registrado no plano.");

    foreach (var aluno in planoAntigo.Alunos)
    {
        ctx.Entry(aluno).State = EntityState.Detached;
        aluno.PlanoId = planoNovo.Id;
        aluno.Plano = planoNovo;

        ctx.Alunos.Attach(aluno);
        ctx.Entry(aluno).State = EntityState.Modified;
    }

    await ctx.SaveChangesAsync();
    return Results.Ok($"Todos os alunos foram movidos do plano '{planoAntigo.NomePlano}' para o plano '{planoNovo.NomePlano}'.");
});

app.MapGet("/api/plano/listar", async (AppDataContext ctx) =>
{
    var planos = await ctx.Planos
        .Include(p => p.Alunos)
        .ToListAsync();

    if (!planos.Any())
        return Results.NotFound("Não há planos cadastrados.");

    return Results.Ok(planos);
});

app.Run();
