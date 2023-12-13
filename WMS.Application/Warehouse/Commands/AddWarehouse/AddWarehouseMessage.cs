namespace WMS.Application.Warehouse.Commands.AddWarehouse;

public sealed record AddWarehouseMessage(Guid Id, string Location, int Capacity);