using MediatR;

namespace WMS.Application.Order.Queries;

public sealed record GetAllOrdersQuery : IRequest<IEnumerable<OrderResponse>>;