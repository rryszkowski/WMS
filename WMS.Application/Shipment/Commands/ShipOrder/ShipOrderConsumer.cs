using System.Data;
using Dapper;
using MassTransit;

namespace WMS.Application.Shipment.Commands.ShipOrder;

public class ShipOrderConsumer : IConsumer<ShipOrderMessage>
{
    private readonly IDbConnection _connection;

    public ShipOrderConsumer(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task Consume(ConsumeContext<ShipOrderMessage> context)
    {
        const string sql = "INSERT INTO Shipment (Id, OrderId, WarehouseId, Status) VALUES (@Id, @OrderId, @WarehouseId, @Status);";

        _connection.Execute(sql, context.Message);

        return Task.CompletedTask;
    }
}