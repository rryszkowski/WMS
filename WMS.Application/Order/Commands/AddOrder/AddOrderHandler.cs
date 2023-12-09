using MediatR;
using WMS.Domain.Entities;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Application.Order.Commands.AddOrder;

public class AddOrderHandler : IRequestHandler<AddOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var customer = await _unitOfWork.Customers.GetAsync(dto.CustomerId);

        if (customer == null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        var order = new Domain.Entities.Order(dto.CustomerId);

        await _unitOfWork.Orders.AddAsync(order);

        foreach (var detail in dto.OrderDetails)
        {
            var product = await _unitOfWork.Products.GetAsync(detail.ProductId);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            order.OrderDetails.Add(new OrderDetails(order.Id, detail.ProductId, detail.Quantity));
        }

        await _unitOfWork.SaveChangesAsync();

        return order.Id;
    }
}