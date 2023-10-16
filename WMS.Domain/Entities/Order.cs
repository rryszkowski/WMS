using WMS.Domain.Base;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

public class Order : Entity
{
    public string CustomerId { get; set; } = null!;
    public OrderStatus Status { get; set; }
}