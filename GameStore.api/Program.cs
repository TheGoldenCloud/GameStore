using GameStore.api.Entities;
using GameStore.api.Endpoints;
using GameStore.api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var constr = builder.Configuration.GetConnectionString("GameStoreContext");

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
