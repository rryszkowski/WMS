namespace WMS.Application.Order.Commands.AddOrder;

public sealed record AddOrderDetailsMessage(Guid Id, Guid OrderId, Guid ProductId, int Quantity);