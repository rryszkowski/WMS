using MediatR;
using WMS.Application.Order.Commands.AddOrder;

namespace WMS.Api.Modules;

public static class OrderModule
{
    public static IEndpointRouteBuilder UseOrderModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/order", async (AddOrderRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddOrderCommand(request))))
            .WithTags("Order");

        return builder;
    }
}