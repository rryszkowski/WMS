namespace WMS.Application.Shipment.Queries;

public sealed class ShipmentResponse
{
    public int ShipmentViewId { get; set; }
    public Guid ShipmentId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WarehouseId { get; set; }
    public string Status { get; set; } = null!;
    public int TotalQuantity { get; set; }
}