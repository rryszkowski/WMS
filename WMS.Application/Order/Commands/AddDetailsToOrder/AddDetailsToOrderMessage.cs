namespace WMS.Application.Order.Commands.AddDetailsToOrder;

public sealed record AddDetailsToOrderMessage(Guid Id, Guid OrderId, Guid ProductId, int Quantity);