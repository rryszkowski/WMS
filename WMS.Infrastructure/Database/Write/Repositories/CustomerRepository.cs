using WMS.Domain.Entities;
using WMS.Infrastructure.Database.Write.Repositories.Base;
using WMS.Infrastructure.Database.Write.Repositories.Interfaces;

namespace WMS.Infrastructure.Database.Write.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(WriteContext context) : base(context)
    {
    }
}