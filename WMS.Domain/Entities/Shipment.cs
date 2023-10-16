using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Shipment : Entity
{
    public string OrderId { get; set; } = null!;
    public string WarehouseId { get; set; } = null!;
    public ShipmentStatus Status { get; set; }
}