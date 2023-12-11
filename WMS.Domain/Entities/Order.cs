using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Order : BaseEntity
{
    public Order(Guid customerId)
    {
        CustomerId = customerId;
        Status = OrderStatus.New;
        OrderDetails = new List<OrderDetails>();
    }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;


    public OrderStatus Status { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; }
}