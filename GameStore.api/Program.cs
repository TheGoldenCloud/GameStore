using GameStore.api.Entities;
using GameStore.api.Endpoints;
using GameStore.api.Repositories;
using GameStore.api.Data;
using Microsoft.EntityFrameworkCore;

//https://www.youtube.com/watch?v=bKCzoR01lpE

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.configuration);
// builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();
// builder.Services.AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

// var constr = builder.Configuration.GetConnectionString("GameStoreContext");
// builder.Services.AddSqlServer<GameStoreContext>(constr);

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var dbcontext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
//     dbcontext.Database.Migrate();
// }

//app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
