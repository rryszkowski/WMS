using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Inventory : Entity
{
    public string ProductId { get; set; } = null!;
    public string WarehouseId { get; set; } = null!;
    public int Quantity { get; set; }
}