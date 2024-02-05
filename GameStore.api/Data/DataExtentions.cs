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
}

//Unhandled exception. Microsoft.Data.SqlClient.SqlException (0x80131904): Login failed for user 'sa'.