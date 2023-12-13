using MassTransit;
using MediatR;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Product.Commands.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public AddProductHandler(IUnitOfWork unitOfWork, IBus bus)
    {
        _unitOfWork = unitOfWork;
        _bus = bus;
    }

    public async  Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var product = new Domain.Entities.Product(
            dto.Name, 
            dto.Category, 
            dto.Manufacturer);

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        await _bus.Publish(new AddProductMessage(
            product.Id,
            product.Name,
            product.Category,
            product.Manufacturer), cancellationToken);

        return product.Id;
    }
}