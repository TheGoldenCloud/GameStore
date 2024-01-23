using GameStore.api.Entities;

List<Game> game = new(){    //In memory
    new Game(){ Id = 1, Name = "Street Mortal combat", Genre= "Fighting", Price = 19.99M, ReleaseDate = new DateTime(1991,2,1), ImageUri = "https:/placeholder.co/100" },
    new Game(){ Id = 2, Name = "Street Final Fantasy XIV", Genre= "Roleplaying", Price = 59.99M, ReleaseDate = new DateTime(2010,9,30), ImageUri = "https:/placeholder.co/100" },
    new Game(){ Id = 3, Name = "Street Pes 10", Genre= "Sports", Price = 69.99M, ReleaseDate = new DateTime(2022,9,27), ImageUri = "https:/placeholder.co/100" }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/home", () => "This is for testing purpeses!");

app.MapGet("/game/{id}", (int id) =>
{
    Game? game_ = game.Find(game => game.Id == id);

    if (game_ is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
});

string gamess()
{
    string allgames = "";
    for (int i = 0; i <= game.Count - 1; i++)
    {
        allgames += "Name: " + game[i].Name + " price: " + game[i].Price + "\n";
    }
    return allgames;
}


app.MapGet("/data", () => gamess());

app.Run();
