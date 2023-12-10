using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.Repositories.Base;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(WriteContext context) : base(context)
    {
    }
}