using Dapper;
using MassTransit;
using System.Data;

namespace WMS.Application.Order.Commands.AddOrder;

public class AddOrderConsumer : IConsumer<AddOrderMessage>
{
    private readonly IDbConnection _connection;

    public AddOrderConsumer(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task Consume(ConsumeContext<AddOrderMessage> context)
    {
        _connection.Open();

        var transaction = _connection.BeginTransaction();

        try
        {
            const string orderSql = "INSERT INTO `Order` (Id, CustomerId, Status) VALUES (@Id, @CustomerId, @Status);";

            _connection.Execute(orderSql, context.Message);

            foreach (var orderDetail in context.Message.OrderDetails)
            {
                const string orderDetailsSql = "INSERT INTO OrderDetails (Id, OrderId, ProductId, Quantity) VALUES (@Id, @OrderId, @ProductId, @Quantity);";

                _connection.Execute(orderDetailsSql, orderDetail);
            }

            transaction.Commit();
            
            _connection.Close();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            _connection.Close();

            throw;
        }
        
        return Task.CompletedTask;
    }
}