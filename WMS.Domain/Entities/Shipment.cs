using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Shipment : BaseEntity
{
    public string OrderId { get; set; } = null!;
    public Order Order { get; set; } = null!;

    public string WarehouseId { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;

    public ShipmentStatus Status { get; set; }
}