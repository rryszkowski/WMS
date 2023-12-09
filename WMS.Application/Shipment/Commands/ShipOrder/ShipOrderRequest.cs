namespace WMS.Application.Shipment.Commands.ShipOrder;

public sealed record ShipOrderRequest(Guid OrderId, Guid WarehouseId);