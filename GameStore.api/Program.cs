using GameStore.api.Entities;
using GameStore.api.Endpoints;
using GameStore.api.Repositories;
using GameStore.api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var constr = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(constr);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
