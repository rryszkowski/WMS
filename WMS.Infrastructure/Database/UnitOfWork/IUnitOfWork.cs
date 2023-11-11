using WMS.Infrastructure.Database.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository Customers { get; }
    IInventoryRepository Inventories { get; }
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
    IShipmentRepository Shipments { get; }
    IWarehouseRepository Warehouses { get; }

    Task<int> SaveChangesAsync();
}