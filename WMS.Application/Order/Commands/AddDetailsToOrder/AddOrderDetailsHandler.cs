using MediatR;
using WMS.Application.Order.Commands.AddDetailsToOrder;
using WMS.Domain.Entities;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Application.Order.Commands.AddOrderDetails;

public class AddOrderDetailsHandler : IRequestHandler<AddDetailsToOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddOrderDetailsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

        return orderDetails.Id;
    }
}