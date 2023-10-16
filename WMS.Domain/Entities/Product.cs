using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
}