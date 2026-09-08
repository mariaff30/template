using AppProject.Core.API.Bootstraps;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiServices();

// Aqui é onde faz de fato o build da aplicação, ou seja, é onde a aplicação é construída e configurada com base nas definições feitas no builder.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiPipeline();

app.Run();
