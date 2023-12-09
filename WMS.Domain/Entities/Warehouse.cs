using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Warehouse : BaseEntity
{
    public Warehouse(string location, int capacity)
    {
        Location = location;
        Capacity = capacity;
    }

    public string Location { get; set; }
    public int Capacity { get; set; }
}