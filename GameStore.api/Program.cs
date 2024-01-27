using GameStore.api.Entities;
using GameStore.api.Endpoints;
using GameStore.api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
