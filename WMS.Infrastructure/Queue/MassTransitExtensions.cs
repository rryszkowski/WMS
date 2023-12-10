using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace WMS.Infrastructure.Queue;

public static class MassTransitExtensions
{
    public static void AddQueue(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.Load("WMS.Application"));

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("db.synchro.queue", "/", h =>
                {
                    h.Username("admin");
                    h.Password("Swordfish123");
                });
            });
        });
    }
}