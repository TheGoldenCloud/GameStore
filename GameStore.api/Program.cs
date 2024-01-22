using GameStore.api.Entities;

List<Game> game = new(){
    new Game(){ Name = "Street Fighter II", Genre= "Fighting", Price = 19.99M, ReleaseDate = new DateTime(1991,2,1), ImageUri = "https:/placeholder.co/100" }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/home", () => "This is for testing purpeses!");

app.MapGet("/data", () => "{ data:300, samsung:200 }");

app.Run();
