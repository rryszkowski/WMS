using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Inventory : BaseEntity
{
    public Inventory(
        Guid productId, 
        Guid warehouseId, 
        int quantity)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        Quantity = quantity;
    }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;
    
    public int Quantity { get; set; }
}