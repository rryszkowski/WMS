using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Customer : BaseEntity
{
    public Customer(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = null!;
}