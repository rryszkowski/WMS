using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Shipment : BaseEntity
{
    public Shipment(Guid orderId, Guid warehouseId)
    {
        OrderId = orderId;
        WarehouseId = warehouseId;
        Status = ShipmentStatus.InTransit;
    }

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;

    public ShipmentStatus Status { get; set; }
}