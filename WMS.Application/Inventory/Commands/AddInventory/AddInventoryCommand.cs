using MediatR;

namespace WMS.Application.Inventory.Commands.AddInventory;

public sealed record AddInventoryCommand(AddInventoryRequest Dto) : IRequest<Guid>;