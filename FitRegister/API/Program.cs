using API.Models;
using Microsoft.AspNetCore.Mvc;
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
app.MapGet("/api/aluno/listar", async (AppDataContext ctx, HttpRequest request) => 
{
    // Obtendo parâmetros da query string
    var page = int.TryParse(request.Query["page"], out var p) ? p : 1;
    var limit = int.TryParse(request.Query["limit"], out var l) ? l : 10;
    var nomeLike = request.Query["nome_like"].ToString() ?? string.Empty;

    // Calculando o offset para a paginação
    var offset = (page - 1) * limit;

    // Buscando os alunos do banco de dados
    var query = ctx.Alunos
        .Include(a => a.Exercicio)
        .Include(b => b.Plano)
        .AsQueryable();
    

    // Aplicando o filtro por nome (se fornecido)
    if (!string.IsNullOrEmpty(nomeLike))
    {
        query = query.Where(a => a.Nome.Contains(nomeLike)); // Certifique-se de que `Nome` é um campo existente
    }

    // Obtendo o total de registros filtrados
    var totalCount = await query.CountAsync();

    // Aplicando a paginação
    var alunos = await query.Skip(offset).Take(limit).ToListAsync();

    // Incluindo o total de registros no cabeçalho de resposta
    request.HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());

    // Retornando os alunos paginados
    return alunos.Any() ? Results.Ok(alunos) : Results.NotFound("Nenhum aluno encontrado.");
});

app.MapPost("/api/aluno/cadastrar", async (AppDataContext ctx, Aluno aluno) => 
{
    var alunoNovo = new Aluno(aluno.Nome, aluno.Endereco, aluno.Telefone, aluno.Email, aluno.Senha, aluno.PlanoId, aluno.ExercicioId);
    ctx.Alunos.Add(alunoNovo);
    await ctx.SaveChangesAsync();
    return Results.Ok(alunoNovo);
});

app.MapGet("/api/aluno/buscar/{id}", async (AppDataContext ctx, Guid id) => 
{
    var aluno = await ctx.Alunos.Include(a => a.Plano).Include(a => a.Exercicio).FirstOrDefaultAsync(a => a.Id == id);
    Console.WriteLine(aluno.Plano);
    return aluno is not null ? Results.Ok(aluno) : Results.NotFound("Aluno não encontrado.");
});

app.MapPut("/api/aluno/add-exercicio/{id}", async (AppDataContext ctx, Guid id, [FromBody] Guid exercicioId) =>
{
    // Procurando o aluno pelo ID
    var aluno = await ctx.Alunos.Include(a => a.Exercicio).FirstOrDefaultAsync(a => a.Id == id);

    if (aluno == null)
    {
        return Results.NotFound("Aluno não encontrado.");
    }

    // Procurando o exercício pelo ID
    var exercicio = await ctx.Exercicios.FindAsync(exercicioId);

    if (exercicio == null)
    {
        return Results.NotFound("Exercício não encontrado.");
    }

    // Associando o exercício ao aluno
    aluno.ExercicioId = exercicioId;

    // Salvando as mudanças no banco de dados
    await ctx.SaveChangesAsync();

    return Results.Ok(aluno);  // Retorna o aluno atualizado com o exercício
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
    
    aluno.PlanoId = alunoUpdt.PlanoId ?? aluno.PlanoId;
    aluno.ExercicioId = alunoUpdt.ExercicioId ?? aluno.ExercicioId;

    ctx.Alunos.Update(aluno);
    await ctx.SaveChangesAsync();
    return Results.Ok(aluno);
});

//Requisições para professor
app.MapPost("/api/professor/cadastrar", async (AppDataContext ctx, Professor professor) => 
{
    var professorNovo = new Professor(professor.Nome, professor.Endereco, professor.Telefone, professor.Email, professor.Senha, professor.ExercicioId);
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

app.MapGet("/api/exercicios/listar", async (HttpRequest request, AppDataContext ctx) =>
{   
    var page = int.TryParse(request.Query["page"], out var p) ? p : 1;
    var limit = int.TryParse(request.Query["limit"], out var l) ? l : 10;
    var nomeLike = request.Query["nome_like"].ToString() ?? string.Empty;

    var offset = (page - 1) * limit;

    var query = ctx.Exercicios.AsQueryable();

    if (!string.IsNullOrEmpty(nomeLike))
    {
        query = query.Where(p => p.Nome.Contains(nomeLike));
    }
    var totalCount = await query.CountAsync();

    var exercicios = await query.Skip(offset).Take(limit).ToListAsync();

    request.HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());
    
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

app.MapPut("/api/exercicios/alterar", async (AppDataContext ctx, Exercicio exercicioAlterado) =>
{
    var exercicio = await ctx.Exercicios.FindAsync(exercicioAlterado.Id);
    if (exercicio == null)
    {
        return Results.NotFound($"Nenhum exercício encontrado com o ID '{exercicioAlterado.Id}'.");
    }

    exercicio.Nome = exercicioAlterado.Nome;
    exercicio.GrupoMuscular = exercicioAlterado.GrupoMuscular;
    exercicio.Descricao = exercicioAlterado.Descricao;
    exercicio.Repeticoes = exercicioAlterado.Repeticoes;
    exercicio.TempoDescanso = exercicioAlterado.TempoDescanso;

    await ctx.SaveChangesAsync();
    return Results.Ok(exercicio);
});

//Requisições para plano
app.MapPost("/api/plano/cadastrar", async (AppDataContext ctx, Plano plano) =>
{
    ctx.Planos.Add(plano);
    await ctx.SaveChangesAsync();
    return Results.Ok(plano);
});

app.MapPut("/api/plano/atualizar/", async (AppDataContext ctx, Plano planoAlterado) =>
{
    var plano = await ctx.Planos.FindAsync(planoAlterado.Id);

    if (plano == null)
        return Results.NotFound(new { Message = "Plano não encontrado" });

    // Atualiza os campos do plano, mantendo os valores existentes quando o novo valor for nulo.
    plano.NomePlano = planoAlterado.NomePlano ?? plano.NomePlano;
    plano.Valor = planoAlterado.Valor = plano.Valor;
    plano.Parcelas = planoAlterado.Parcelas = plano.Parcelas;

    // Verifica se o nome do plano já existe (mantendo a lógica original)
    if (await ctx.Planos.AnyAsync(p => p.NomePlano.ToLower() == planoAlterado.NomePlano.ToLower() && p.Id != plano.Id))
        return Results.BadRequest(new { Message = "Já existe um plano com esse nome." });

    // Atualiza o plano no banco de dados
    ctx.Planos.Update(plano);
    await ctx.SaveChangesAsync();

    return Results.Ok(plano);
});


app.MapDelete("/api/plano/deletar/{id}", async (AppDataContext ctx, Guid id) =>
{
    var plano = await ctx.Planos.FirstOrDefaultAsync(p => p.Id == id);

    if (plano == null)
        return Results.NotFound("Insira um ID valido.");

    ctx.Planos.Remove(plano);
    await ctx.SaveChangesAsync();
    return Results.Ok(plano);
});

app.MapGet("/api/plano/buscar/{id}", async (AppDataContext ctx, Guid id) =>
{
    var plano = await ctx.Planos.FirstOrDefaultAsync(a => a.Id == id);

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

app.MapGet("/api/plano/listar", async (HttpRequest request, AppDataContext ctx) =>
{
    var page = int.TryParse(request.Query["page"], out var p) ? p : 1;
    var limit = int.TryParse(request.Query["limit"], out var l) ? l : 10;
    var nomeLike = request.Query["nome_like"].ToString() ?? string.Empty;

    var offset = (page - 1) * limit;

    var query = ctx.Planos.AsQueryable();

    if (!string.IsNullOrEmpty(nomeLike))
    {
        query = query.Where(p => p.NomePlano.Contains(nomeLike));
    }
    var totalCount = await query.CountAsync();

    var planos = await query.Skip(offset).Take(limit).ToListAsync();

    request.HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());

    return planos.Any() ? Results.Ok(planos) : Results.NotFound("Nenhum plano encontrado.");
});

//Dashboard
app.MapGet("/api/dashboard", async (AppDataContext context) =>
{
    var data = new DashboardData
    {
        Alunos = await context.Alunos.CountAsync(),
        Professores = await context.Professores.CountAsync(),
        Planos = await context.Planos.CountAsync(),
        Exercicios = await context.Exercicios.CountAsync()
    };

    return Results.Ok(data);
});

//login
app.MapPost("/api/login", async( AppDataContext ctx, LoginRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Senha))
    {
        return Results.BadRequest("Email e senha são obrigatórios.");
    }
    var aluno = await ctx.Alunos.FirstOrDefaultAsync(a => a.Email == request.Email);
    if(aluno != null && aluno.Senha == request.Senha)
    {
        return Results.Ok(new { Role = "Aluno", Nome = aluno.Nome, Id = aluno.Id });
    }

    var professor = await ctx.Professores.FirstOrDefaultAsync(p => p.Email == request.Email);
    if (professor != null && professor.Senha == request.Senha)
    {
        return Results.Ok(new { Role = "Professor", Nome = professor.Nome, Id = professor.Id });
    }

    return Results.NotFound("Usuário ou senha incorretos.");   
});

app.Run();
