using Persistence;
using Application;
using API.Endpoints;
using API.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseServices();
builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}
// Seed data
Initializer.SeedData(app.Services);

app.MapPokemonEndpoint();

app.Run();
