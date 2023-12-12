namespace WMS.Application.Inventory.Commands.AddInventory;

public sealed record AddInventoryMessage(
    Guid Id,
    Guid ProductId,
    Guid WarehouseId,
    int Quantity);