namespace WMS.Application.Product.Queries;

public sealed class ProductSummaryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int AvailableQuantity { get; set; }
}