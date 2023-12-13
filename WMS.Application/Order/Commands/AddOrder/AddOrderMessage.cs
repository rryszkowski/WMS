namespace WMS.Application.Order.Commands.AddOrder;

public sealed record AddOrderMessage(
    Guid Id,
    Guid CustomerId,
    string Status,
    ICollection<AddOrderDetailsMessage> OrderDetails);