namespace WMS.Application.Inventory.Queries;

public sealed class InventorySummaryResponse
{
    public int InventoryViewId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string WarehouseLocation { get; set; } = null!;
    public int Quantity { get; set; }
}