using MediatR;
using WMS.Application.Warehouse.Commands.AddWarehouse;

namespace WMS.Api.Modules;

public static class WarehouseModule
{
    public static void UseWarehouseModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/warehouse", async (AddWarehouseRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddWarehouseCommand(request))))
            .WithTags("Warehouse");
    }
}