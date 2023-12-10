using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.Repositories.Base;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.Repositories;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(WriteContext context) : base(context)
    {
    }
}