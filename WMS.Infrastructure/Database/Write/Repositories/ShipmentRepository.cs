using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.Repositories.Base;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.Repositories;

public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(WriteContext context) : base(context)
    {
    }
}