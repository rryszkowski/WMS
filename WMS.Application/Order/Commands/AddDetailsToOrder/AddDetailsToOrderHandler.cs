using MassTransit;
using MediatR;
using WMS.Application.Order.Commands.AddDetailsToOrder;
using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Order.Commands.AddOrderDetails;

public class AddDetailsToOrderHandler : IRequestHandler<AddDetailsToOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public AddDetailsToOrderHandler(IUnitOfWork unitOfWork, IBus bus)
    {
        _unitOfWork = unitOfWork;
        _bus = bus;
    }

    public async  Task<Guid> Handle(AddDetailsToOrderCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var order = await _unitOfWork.Orders.GetAsync(request.OrderId);

        if (order == null)
        {
            throw new InvalidOperationException("Order not found");
        }

        var product = await _unitOfWork.Products.GetAsync(dto.ProductId);

        if (product == null)
        {
            throw new InvalidOperationException("Product not found");
        }

        var orderDetails = new OrderDetails(request.OrderId, dto.ProductId, dto.Quantity);

        order.OrderDetails.Add(orderDetails);

        await _unitOfWork.SaveChangesAsync();

        await _bus.Publish(
            new AddDetailsToOrderMessage(
                orderDetails.Id,
                orderDetails.OrderId,
                orderDetails.ProductId,
                orderDetails.Quantity), cancellationToken);

        return orderDetails.Id;
    }
}