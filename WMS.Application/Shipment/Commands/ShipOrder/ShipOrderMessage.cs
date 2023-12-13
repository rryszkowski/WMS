namespace WMS.Application.Shipment.Commands.ShipOrder;

public sealed record ShipOrderMessage(Guid Id, Guid OrderId, Guid WarehouseId, string Status);