namespace WMS.Application.Product.Commands.AddProduct;

public sealed record AddProductRequest(
    string Name,
    string Category,
    string Manufacturer);