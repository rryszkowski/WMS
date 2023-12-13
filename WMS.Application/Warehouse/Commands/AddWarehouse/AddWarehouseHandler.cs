using MassTransit;
using MediatR;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Warehouse.Commands.AddWarehouse;

public class AddWarehouseHandler : IRequestHandler<AddWarehouseCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public AddWarehouseHandler(IUnitOfWork unitOfWork, IBus bus)
    {
        _unitOfWork = unitOfWork;
        _bus = bus;
    }

    public async Task<Guid> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var warehouse = new Domain.Entities.Warehouse(
            dto.Location,
            dto.Capacity);

        await _unitOfWork.Warehouses.AddAsync(warehouse);
        await _unitOfWork.SaveChangesAsync();

        await _bus.Publish(new AddWarehouseMessage(
                warehouse.Id,
                warehouse.Location,
                warehouse.Capacity),
            cancellationToken);

        return warehouse.Id;
    }
}