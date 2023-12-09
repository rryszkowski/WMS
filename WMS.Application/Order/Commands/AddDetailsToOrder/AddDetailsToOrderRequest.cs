namespace WMS.Application.Order.Commands.AddDetailsToOrder;

public record AddDetailsToOrderRequest(Guid ProductId, int Quantity);