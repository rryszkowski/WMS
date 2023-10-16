using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class OrderDetails : Entity
{
    public string OrderId { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
}