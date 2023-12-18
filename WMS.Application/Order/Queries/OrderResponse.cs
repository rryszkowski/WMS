namespace WMS.Application.Order.Queries;

public sealed class OrderResponse
{
    public int OrderViewId { get; set; }
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public string Status { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public int TotalProducts { get; set; }
}