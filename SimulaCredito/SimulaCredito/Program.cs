using SimulaCredito.Models.Context;
using SimulaCredito.Business;
using SimulaCredito.Business.Implementations;
using SimulaCredito.Repository;
using SimulaCredito.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SqlContext>();

builder.Services.AddControllers();

//versionamento de API
builder.Services.AddApiVersioning();

builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();
builder.Services.AddScoped<ITipoFinanciamentoBusiness, TipoFinanciamentoBusiness>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
