using WMS.Application.Order.Commands.AddOrderDetails;

namespace WMS.Application.Order.Commands.AddOrder;

public sealed record AddOrderRequest(
    Guid CustomerId,
    ICollection<AddOrderDetailsRequest> OrderDetails);