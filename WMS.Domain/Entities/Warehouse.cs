using WMS.Domain.Base;

namespace WMS.Domain.Entities;

public class Warehouse : Entity
{
    public string Location { get; set; } = null!;
    public int Capacity { get; set; }
}