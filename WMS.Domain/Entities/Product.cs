using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Product : BaseEntity
{
    public Product(
        string name, 
        string category, 
        string manufacturer)
    {
        Name = name;
        Category = category;
        Manufacturer = manufacturer;
    }

    public string Name { get; set; }
    public string Category { get; set; }
    public string Manufacturer { get; set; }
}