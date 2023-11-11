using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Repositories.Base;
using WMS.Infrastructure.Database.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Repositories;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(WriteContext context) : base(context)
    {
    }
}