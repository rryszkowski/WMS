using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly WriteContext _context;

    public UnitOfWork(
        WriteContext context,
        ICustomerRepository customers,
        IInventoryRepository inventories,
        IOrderRepository orders,
        IProductRepository products,
        IShipmentRepository shipments,
        IWarehouseRepository warehouses)
    {
        _context = context;

        Customers = customers;
        Inventories = inventories;
        Orders = orders;
        Products = products;
        Shipments = shipments;
        Warehouses = warehouses;
    }

    public ICustomerRepository Customers { get; }
    public IInventoryRepository Inventories { get; }
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    public IShipmentRepository Shipments { get; }
    public IWarehouseRepository Warehouses { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }
}