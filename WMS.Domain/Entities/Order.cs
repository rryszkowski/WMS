using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;


    public OrderStatus Status { get; set; }

    public Guid OrderDetailsId { get; set; }
    public OrderDetails OrderDetails { get; set; } = null!;
}