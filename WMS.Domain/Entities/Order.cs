using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Order : BaseEntity
{
    public string CustomerId { get; set; } = null!;
    public Customer Customer { get; set; } = null!;


    public OrderStatus Status { get; set; }

    public string OrderDetailsId { get; set; } = null!;
    public OrderDetails OrderDetails { get; set; } = null!;
}