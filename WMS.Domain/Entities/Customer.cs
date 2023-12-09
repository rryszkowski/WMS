using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; } = null!;
}