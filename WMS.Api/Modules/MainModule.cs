namespace WMS.Api.Modules;

public static class MainModule
{
    public static void UseModules(this IEndpointRouteBuilder app)
    {
        app.UseCustomerModule()
            .UseInventoryModule()
            .UseOrderModule()
            .UseProductModule()
            .UseWarehouseModule();
    }
}