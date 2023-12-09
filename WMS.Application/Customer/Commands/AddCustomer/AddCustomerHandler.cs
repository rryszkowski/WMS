using MediatR;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Application.Customer.Commands.AddCustomer;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customer(request.Dto.Name);
        await _unitOfWork.Customers.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        return customer.Id;
    }
}