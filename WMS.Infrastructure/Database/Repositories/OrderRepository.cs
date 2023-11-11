using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Repositories.Base;
using WMS.Infrastructure.Database.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(WriteContext context) : base(context)
    {
    }
}