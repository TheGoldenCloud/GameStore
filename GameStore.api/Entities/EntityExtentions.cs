using GameStore.api.Dtos;

namespace GameStore.api.Entities;

public static class EntityExtention
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(game.Id, game.Name, game.Genre, game.Price, game.ReleaseDate, game.ImageUri);
    }
}