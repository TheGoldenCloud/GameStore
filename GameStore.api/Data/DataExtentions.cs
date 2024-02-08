using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data;

public static class DataExtentions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbcontext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var constr = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(constr).AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

        return services;
    }
}

//Unhandled exception. Microsoft.Data.SqlClient.SqlException (0x80131904): Login failed for user 'sa'.