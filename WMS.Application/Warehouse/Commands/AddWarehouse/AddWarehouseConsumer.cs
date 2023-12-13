using System.Data;
using Dapper;
using MassTransit;

namespace WMS.Application.Warehouse.Commands.AddWarehouse;

public class AddWarehouseConsumer : IConsumer<AddWarehouseMessage>
{
    private readonly IDbConnection _connection;

    public AddWarehouseConsumer(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task Consume(ConsumeContext<AddWarehouseMessage> context)
    {
        const string sql = "INSERT INTO Warehouse (Id, Location, Capacity) VALUES (@Id, @Location, @Capacity);";

        _connection.Execute(sql, context.Message);

        return Task.CompletedTask;
    }
}