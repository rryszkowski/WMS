using MediatR;
using WMS.Application.Product.Commands.AddProduct;
using WMS.Application.Product.Queries;

namespace WMS.Api.Modules;

public static class ProductModule
{
    public static IEndpointRouteBuilder UseProductModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/product", async (AddProductRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddProductCommand(request))))
            .WithTags("Product");

        builder
            .MapGet("/api/product", async (ISender sender)
                => Results.Ok(await sender.Send(new GetProductSummaryQuery())))
            .WithTags("Product");

        return builder;
    }
}