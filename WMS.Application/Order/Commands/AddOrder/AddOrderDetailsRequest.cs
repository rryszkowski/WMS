namespace WMS.Application.Order.Commands.AddOrder;

public sealed record AddOrderDetailsRequest(Guid ProductId, int Quantity);