using MediatR;
using WMS.Application.Inventory.Commands.AddInventory;

namespace WMS.Api.Modules;

public static class InventoryModule
{
    public static IEndpointRouteBuilder UseInventoryModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/inventory", async (AddInventoryRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddInventoryCommand(request))))
            .WithTags("Inventory");

        return builder;
    }
}