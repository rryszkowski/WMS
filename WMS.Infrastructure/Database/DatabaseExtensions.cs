using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WMS.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static void AddWriteContext(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider()
            .GetRequiredService<IConfiguration>();
        
        var connectionString = configuration.GetConnectionString("WriteDb");

        services.AddDbContext<WriteContext>(options => options.UseNpgsql(connectionString));
    }
}