using MediatR;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Application.Inventory.Commands.AddInventory;

public class AddInventoryHandler : IRequestHandler<AddInventoryCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddInventoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var product = await _unitOfWork.Products.GetAsync(dto.ProductId);

        if (product == null)
        {
            throw new InvalidOperationException("Product not found");
        }

        var warehouse = await _unitOfWork.Warehouses.GetAsync(dto.WarehouseId);

        if (warehouse == null)
        {
            throw new InvalidOperationException("Warehouse not found");
        }

        if (warehouse.Capacity < dto.Quantity)
        {
            throw new InvalidOperationException("Insufficient warehouse capacity");
        }

        var inventory = new Domain.Entities.Inventory(
            dto.ProductId, 
            dto.WarehouseId, 
            dto.Quantity);

        await _unitOfWork.Inventories.AddAsync(inventory);
        await _unitOfWork.SaveChangesAsync();

        return inventory.Id;
    }
}