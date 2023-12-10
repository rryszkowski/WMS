using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WMS.Infrastructure.Database.Write.Repositories;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Infrastructure.Database.Write;

public static class WriteDatabaseExtensions
{
    public static void AddWriteDatabase(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider()
            .GetRequiredService<IConfiguration>();
        
        var connectionString = configuration.GetConnectionString("WriteDb");

        services
            .AddDbContext<WriteContext>(options => options.UseNpgsql(connectionString));

        var writeContext = services.BuildServiceProvider()
            .GetRequiredService<WriteContext>();

        writeContext.Database.Migrate();

        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IInventoryRepository, InventoryRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IShipmentRepository, ShipmentRepository>()
            .AddScoped<IWarehouseRepository, WarehouseRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}