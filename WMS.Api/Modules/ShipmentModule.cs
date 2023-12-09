using MediatR;
using WMS.Application.Shipment.Commands.ShipOrder;

namespace WMS.Api.Modules;

public static class ShipmentModule
{
    public static IEndpointRouteBuilder UseShipmentModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/shipment", async (ShipOrderRequest request, ISender sender)
                => Results.Ok(await sender.Send(new ShipOrderCommand(request))))
            .WithTags("Shipment");

        return builder;
    }
}