using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Repositories.Base;
using WMS.Infrastructure.Database.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(WriteContext context) : base(context)
    {
    }
}