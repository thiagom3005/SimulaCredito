using SimulaCredito.Models.Context;
using SimulaCredito.Business;
using SimulaCredito.Business.Implementations;
using SimulaCredito.Repository;
using SimulaCredito.Repository.Generic;
using SimulaCredito.Repository.Implementations;
using SimulaCredito.Hypermedia.Filters;
using SimulaCredito.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SqlContext>();

builder.Services.AddControllers();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new ClienteEnricher());
filterOptions.ContentResponseEnricherList.Add(new FinanciamentoEnricher());
filterOptions.ContentResponseEnricherList.Add(new TipoFinanciamentoEnricher());

builder.Services.AddSingleton(filterOptions);

//versionamento de API
builder.Services.AddApiVersioning();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Simula Financiamento",
            Version = "v1",
            Description = "Simulação básica de crédito bancário",
            Contact = new OpenApiContact
            {
                Name = "Thiago Guimarães",
                Url = new Uri("https://github.com/thiagom3005/SimulaCredito")
            }
        });
});

builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();
builder.Services.AddScoped<IFinanciamentoBusiness, FinanciamentoBusiness>();
builder.Services.AddScoped<ITipoFinanciamentoBusiness, TipoFinanciamentoBusiness>();
builder.Services.AddScoped<IParcelaBusiness, ParcelaBusiness>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c=>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "Simula Financiamento - v1");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");

app.Run();
