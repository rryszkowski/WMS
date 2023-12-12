using MassTransit;
using MediatR;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Customer.Commands.AddCustomer;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public AddCustomerHandler(
        IUnitOfWork unitOfWork, 
        IBus bus)
    {
        _unitOfWork = unitOfWork;
        _bus = bus;
    }

    public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customer(request.Dto.Name);
        await _unitOfWork.Customers.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        await _bus.Publish(new AddCustomerMessage(customer.Id, customer.Name), cancellationToken);

        return customer.Id;
    }
}