using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Repositories.Base;
using WMS.Infrastructure.Database.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(WriteContext context) : base(context)
    {
    }
}