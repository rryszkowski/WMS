using MediatR;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Application.Warehouse.Commands.AddWarehouse;

public class AddWarehouseHandler : IRequestHandler<AddWarehouseCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddWarehouseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        
        await _unitOfWork.Warehouses.AddAsync(
            new Domain.Entities.Warehouse(dto.Location, dto.Capacity));

        await _unitOfWork.SaveChangesAsync();
    }
}