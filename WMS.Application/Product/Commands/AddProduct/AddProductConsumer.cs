using System.Data;
using Dapper;
using MassTransit;

namespace WMS.Application.Product.Commands.AddProduct;

public class AddProductConsumer : IConsumer<AddProductMessage>
{
    private readonly IDbConnection _connection;

    public AddProductConsumer(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task Consume(ConsumeContext<AddProductMessage> context)
    {
        const string sql = "INSERT INTO Product (Id, Name, Category, Manufacturer) VALUES (@Id, @Name, @Category, @Manufacturer);";

        _connection.Execute(sql, context.Message);

        return Task.CompletedTask;
    }
}