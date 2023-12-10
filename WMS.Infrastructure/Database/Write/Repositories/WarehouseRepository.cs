using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.Repositories.Base;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.Repositories;

public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(WriteContext context) : base(context)
    {
    }
}