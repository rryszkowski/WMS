using MediatR;
using WMS.Application.Customer.Commands.AddCustomer;

namespace WMS.Api.Modules;

public static class CustomerModule
{
    public static void UseCustomerModule(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/customer", async (AddCustomerRequest request, ISender sender)
                => Results.Ok(await sender.Send(new AddCustomerCommand(request))))
            .WithTags("Customer");
    }
}