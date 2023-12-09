namespace WMS.Application.Inventory.Commands.AddInventory;

public sealed record AddInventoryRequest(
    Guid ProductId, 
    Guid WarehouseId, 
    int Quantity);