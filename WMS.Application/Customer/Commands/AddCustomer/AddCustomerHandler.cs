using MediatR;
using WMS.Infrastructure.Database.UnitOfWork;

namespace WMS.Application.Customer.Commands.AddCustomer;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand >
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Customers.AddAsync(new Domain.Entities.Customer(request.Dto.Name));
        await _unitOfWork.SaveChangesAsync();
    }
}