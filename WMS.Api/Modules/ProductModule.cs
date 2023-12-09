using MediatR;
using WMS.Application.Product.Commands.AddProduct;

namespace WMS.Api.Modules;

public static class ProductModule
{
    public static void UseProductModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/product", async (AddProductRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddProductCommand(request))))
            .WithTags("Product");
    }
}