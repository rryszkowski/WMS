namespace WMS.Application.Warehouse.Queries;

public sealed class WarehouseSummaryResponse
{
    public Guid Id { get; set; }
    public string Location { get; set; } = null!;
    public int Capacity { get; set; }
    public int Utilization { get; set; }
}