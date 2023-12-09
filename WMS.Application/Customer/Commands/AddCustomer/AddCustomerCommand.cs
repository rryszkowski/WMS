using MediatR;

namespace WMS.Application.Customer.Commands.AddCustomer;

public sealed record AddCustomerCommand(AddCustomerRequest Dto) : IRequest<Guid>;