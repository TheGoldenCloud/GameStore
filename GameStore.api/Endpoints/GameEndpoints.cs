using GameStore.api.Entities;
using GameStore.api.Repositories;

namespace GameStore.api.Endpoints;

public static class GameEndpoints
{
    static string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        InMemGamesRepository repository = new();

        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", () => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            Game? game_ = repository.Get(id);
            return game_ is not null ? Results.Ok(game_) : Results.NotFound();

        }).WithName(GetGameEndpointName);

        group.MapPost("/games", (Game game) =>
        {
            repository.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/games/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = repository.Get(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            repository.Update(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/games/{id}", (int id) =>
        {
            Game? game = repository.Get(id);

            if (game is not null)
            {
                repository.Delete(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}