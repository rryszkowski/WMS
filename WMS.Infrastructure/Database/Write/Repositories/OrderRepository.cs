using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.Repositories.Base;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(WriteContext context) : base(context)
    {
    }
}