using MediatR;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Warehouse.Commands.AddWarehouse;

public class AddWarehouseHandler : IRequestHandler<AddWarehouseCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddWarehouseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var warehouse = new Domain.Entities.Warehouse(
            dto.Location,
            dto.Capacity);

        await _unitOfWork.Warehouses.AddAsync(warehouse);
        await _unitOfWork.SaveChangesAsync();

        return warehouse.Id;
    }
}