using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WMS.Infrastructure.Database.Read;

public static class ReadDatabaseExtensions
{
    public static void AddReadDatabase(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider()
            .GetRequiredService<IConfiguration>();

        var connectionString = configuration.GetConnectionString("ReadDb");
    }
}