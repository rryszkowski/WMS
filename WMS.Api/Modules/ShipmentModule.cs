using MediatR;
using WMS.Application.Shipment.Commands.ShipOrder;
using WMS.Application.Shipment.Queries;

namespace WMS.Api.Modules;

public static class ShipmentModule
{
    public static IEndpointRouteBuilder UseShipmentModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/shipment", async (ShipOrderRequest request, ISender sender)
                => Results.Ok(await sender.Send(new ShipOrderCommand(request))))
            .WithTags("Shipment");

        builder
            .MapGet("/api/shipment", async (ISender sender)
                => Results.Ok(await sender.Send(new GetAllShipmentsQuery())))
            .WithTags("Shipment");

        return builder;
    }
}