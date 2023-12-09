using MediatR;

namespace WMS.Application.Order.Commands.AddDetailsToOrder;

public sealed record AddDetailsToOrderCommand(Guid OrderId, AddDetailsToOrderRequest Dto) : IRequest<Guid>;