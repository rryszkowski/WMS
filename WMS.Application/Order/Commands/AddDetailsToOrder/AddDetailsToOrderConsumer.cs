using System.Data;
using Dapper;
using MassTransit;

namespace WMS.Application.Order.Commands.AddDetailsToOrder;

public class AddDetailsToOrderConsumer : IConsumer<AddDetailsToOrderMessage>
{
    private readonly IDbConnection _connection;

    public AddDetailsToOrderConsumer(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task Consume(ConsumeContext<AddDetailsToOrderMessage> context)
    {
        const string orderDetailsSql = "INSERT INTO OrderDetails (Id, OrderId, ProductId, Quantity) VALUES (@Id, @OrderId, @ProductId, @Quantity);";

        _connection.Execute(orderDetailsSql, context.Message);

        return Task.CompletedTask;
    }
}