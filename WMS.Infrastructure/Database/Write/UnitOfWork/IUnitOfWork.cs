using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.UnitOfWork;

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