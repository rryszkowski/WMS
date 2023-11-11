using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; } = null!;
}