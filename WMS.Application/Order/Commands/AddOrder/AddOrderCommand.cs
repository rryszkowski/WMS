using MediatR;

namespace WMS.Application.Order.Commands.AddOrder;

public record AddOrderCommand(AddOrderRequest Dto) : IRequest<Guid>;