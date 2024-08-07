using GameStore.api.Dtos;
using GameStore.api.Entities;
using GameStore.api.Repositories;

namespace GameStore.api.Endpoints;

public static class GameEndpoints
{
    static string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        // InMemGamesRepository repository = new();

        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", async (IGamesRepository repository) => (await repository.GetAllAsync()).Select(game => game.AsDto()));

        group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game_ = await repository.Get(id);
            return game_ is not null ? Results.Ok(game_.AsDto()) : Results.NotFound();

        }).WithName(GetGameEndpointName);

        group.MapPost("/games", async (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new() { Name = gameDto.Name, Genre = gameDto.Genre, Price = gameDto.Price, ReleaseDate = gameDto.RelaseDate, ImageUri = gameDto.ImageUri };

            repository.Create(game);
            return await Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/games/{id}", async(IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = repository.Get(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.RelaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            repository.Update(existingGame);

            return await Results.NoContent();
        });

        group.MapDelete("/games/{id}", async(IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);

            if (game is not null)
            {
                repository.Delete(id);
            }

            return await Results.NoContent();
        });

        return group;
    }
}