using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class OrderDetails : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}