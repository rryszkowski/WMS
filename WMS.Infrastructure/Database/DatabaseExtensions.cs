using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WMS.Infrastructure.Database.Repositories;
using WMS.Infrastructure.Database.Repositories.Interfaces;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static void ConfigureWriteDatabase(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider()
            .GetRequiredService<IConfiguration>();
        
        var connectionString = configuration.GetConnectionString("WriteDb");

        services
            .AddDbContext<WriteContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IInventoryRepository, InventoryRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IShipmentRepository, ShipmentRepository>()
            .AddScoped<IWarehouseRepository, WarehouseRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}