

using MementoBd;
using MementoDominio.Manipuladores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(x => new ContextoBd());
builder.Services.AddScoped(x => new CategoriaManipulador(new ContextoBd()));
builder.Services.AddScoped(x => new UsuarioManipulador(new ContextoBd()));
builder.Services.AddScoped(x => new TarefaManipulador(new ContextoBd()));
builder.Services.AddScoped(x => new ListaManipulador(new ContextoBd()));
builder.Services.AddScoped(x => new LoginManipulador(new ContextoBd()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

