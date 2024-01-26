using GameStore.api.Entities;

namespace GameStore.api.Repositories;
public class InMemGamesRepository
{
    private readonly List<Game> games = new(){    //In memory
        new Game(){ Id = 1, Name = "Street Mortal combat", Genre= "Fighting", Price = 19.99M, ReleaseDate = new DateTime(1991,2,1), ImageUri = "https:/placeholder.co/100" },
        new Game(){ Id = 2, Name = "Street Final Fantasy XIV", Genre= "Roleplaying", Price = 59.99M, ReleaseDate = new DateTime(2010,9,30), ImageUri = "https:/placeholder.co/100" },
        new Game(){ Id = 3, Name = "Street Pes 10", Genre= "Sports", Price = 69.99M, ReleaseDate = new DateTime(2022,9,27), ImageUri = "https:/placeholder.co/100" }
    };

    public IEnumerable<Game> GetAll()
    {
        return games;
    }
    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }
    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }
    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}