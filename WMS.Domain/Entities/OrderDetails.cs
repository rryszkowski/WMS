using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class OrderDetails : BaseEntity
{
    public string ProductId { get; set; } = null!;
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}