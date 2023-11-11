using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Inventory : Entity
{
    public string ProductId { get; set; } = null!;
    public Product Product { get; set; } = null!;

    public string WarehouseId { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;
    
    public int Quantity { get; set; }
}