using System.Data;
using Dapper;
using MassTransit;

namespace WMS.Application.Inventory.Commands.AddInventory;

public class AddInventoryConsumer : IConsumer<AddInventoryMessage>
{
    private readonly IDbConnection _connection;

    public AddInventoryConsumer(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task Consume(ConsumeContext<AddInventoryMessage> context)
    {
        const string sql = "INSERT INTO Inventory (Id, ProductId, WarehouseId, Quantity) VALUES (@Id, @ProductId, @WarehouseId, @Quantity);";

        _connection.Execute(sql, context.Message);

        return Task.CompletedTask;
    }
}