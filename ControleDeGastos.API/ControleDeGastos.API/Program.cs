using ControleDeGastos.Core.Interfaces.Repositories;
using ControleDeGastos.Infraestrutura;
using ControleDeGastos.Infraestrutura.Persistencia.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ControleDeGastos");
builder.Services.AddDbContext<ControleDeGastosDbContext>(options =>
                options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPessoasRepository, PessoaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirProjetoFront",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:5173",
                "https://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirProjetoFront");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
