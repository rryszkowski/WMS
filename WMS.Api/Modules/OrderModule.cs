using MediatR;
using WMS.Application.Order.Commands.AddDetailsToOrder;
using WMS.Application.Order.Commands.AddOrder;
using WMS.Application.Order.Queries;

namespace WMS.Api.Modules;

public static class OrderModule
{
    public static IEndpointRouteBuilder UseOrderModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/order", async (AddOrderRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddOrderCommand(request))))
            .WithTags("Order");

        builder
            .MapPost("/api/order/{orderId:guid}/details", async (Guid orderId, AddDetailsToOrderRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddDetailsToOrderCommand(orderId, request))))
            .WithTags("Order");

        builder
            .MapGet("/api/order", async (ISender sender)
                => Results.Ok(await sender.Send(new GetAllOrdersQuery())))
            .WithTags("Order");

        return builder;
    }
}