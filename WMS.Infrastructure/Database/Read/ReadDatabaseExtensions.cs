using System.Data;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace WMS.Infrastructure.Database.Read;

public static class ReadDatabaseExtensions
{
    public static void AddReadDatabase(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider()
            .GetRequiredService<IConfiguration>();

        var connectionString = configuration.GetConnectionString("ReadDb");

        services.AddTransient<IDbConnection>(_ =>
            new MySqlConnection(connectionString));
        
        var upgrader = DeployChanges.To
            .MySqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            throw new InvalidOperationException("Failed to update Read Database");
        }
    }
}