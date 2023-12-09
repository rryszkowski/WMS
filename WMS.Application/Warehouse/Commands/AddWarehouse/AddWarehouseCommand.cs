using MediatR;

namespace WMS.Application.Warehouse.Commands.AddWarehouse;

public record AddWarehouseCommand(AddWarehouseRequest Dto) : IRequest;