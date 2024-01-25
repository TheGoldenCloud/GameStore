using GameStore.api.Entities;

const string GetGameEndpointName = "GetGame";

List<Game> games = new(){    //In memory
    new Game(){ Id = 1, Name = "Street Mortal combat", Genre= "Fighting", Price = 19.99M, ReleaseDate = new DateTime(1991,2,1), ImageUri = "https:/placeholder.co/100" },
    new Game(){ Id = 2, Name = "Street Final Fantasy XIV", Genre= "Roleplaying", Price = 59.99M, ReleaseDate = new DateTime(2010,9,30), ImageUri = "https:/placeholder.co/100" },
    new Game(){ Id = 3, Name = "Street Pes 10", Genre= "Sports", Price = 69.99M, ReleaseDate = new DateTime(2022,9,27), ImageUri = "https:/placeholder.co/100" }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/games").WithParameterValidation();

group.MapGet("/", () => games);

group.MapGet("/{id}", (int id) =>
{
    Game? game_ = games.Find(game => game.Id == id);

    if (game_ is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(games);
}).WithName(GetGameEndpointName);

group.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

group.MapPut("/games/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();
});

group.MapDelete("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);

    if (game is not null)
    {
        games.Remove(game);
    }

    return Results.NoContent();
});




string gamess()
{
    string allgames = "";
    for (int i = 0; i <= games.Count - 1; i++)
    {
        allgames += "Name: " + games[i].Name + " price: " + games[i].Price + "\n";
    }
    return allgames;
}


app.MapGet("/data", () => gamess());

app.Run();
