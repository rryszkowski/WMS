using MassTransit;
using MediatR;
using WMS.Domain.Enums;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Shipment.Commands.ShipOrder;

public class ShipOrderHandler : IRequestHandler<ShipOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public ShipOrderHandler(IUnitOfWork unitOfWork, IBus bus)
    {
        _unitOfWork = unitOfWork;
        _bus = bus;
    }

    public async Task<Guid> Handle(ShipOrderCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var order = await _unitOfWork.Orders.GetAsync(dto.OrderId);

        if (order == null)
        {
            throw new InvalidOperationException("Order not found");
        }

        var warehouse = await _unitOfWork.Warehouses.GetAsync(dto.WarehouseId);

        if (warehouse == null)
        {
            throw new InvalidOperationException("Warehouse not found");
        }

        order.Status = OrderStatus.Shipped;

        var shipment = new Domain.Entities.Shipment(dto.OrderId, dto.WarehouseId);

        await _unitOfWork.Shipments.AddAsync(shipment);
        await _unitOfWork.SaveChangesAsync();

        await _bus.Publish(
            new ShipOrderMessage(
                shipment.Id,
                shipment.OrderId,
                shipment.WarehouseId,
                $"{shipment.Status}"),
            cancellationToken);

        return shipment.Id;
    }
}