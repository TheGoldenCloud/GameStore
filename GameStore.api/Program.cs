using GameStore.api.Entities;
using GameStore.api.Endpoints;
using GameStore.api.Repositories;
using GameStore.api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var constr = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(constr);

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var dbcontext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
//     dbcontext.Database.Migrate();
// }

app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
