using MediatR;
using WMS.Application.Warehouse.Commands.AddWarehouse;
using WMS.Application.Warehouse.Queries;

namespace WMS.Api.Modules;

public static class WarehouseModule
{
    public static IEndpointRouteBuilder UseWarehouseModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/warehouse", async (AddWarehouseRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddWarehouseCommand(request))))
            .WithTags("Warehouse");

        builder
            .MapGet("/api/warehouse", async (ISender sender)
                => Results.Ok(await sender.Send(new GetWarehouseSummaryQuery())))
            .WithTags("Warehouse");

        return builder;
    }
}