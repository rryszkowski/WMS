namespace WMS.Application.Product.Commands.AddProduct;

public sealed record AddProductMessage(
    Guid Id,
    string Name,
    string Category,
    string Manufacturer);