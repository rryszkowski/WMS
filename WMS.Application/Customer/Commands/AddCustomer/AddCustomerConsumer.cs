using System.Data;
using Dapper;
using MassTransit;

namespace WMS.Application.Customer.Commands.AddCustomer;

public class AddCustomerConsumer : IConsumer<AddCustomerMessage>
{
    private readonly IDbConnection _dbConnection;

    public AddCustomerConsumer(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task Consume(ConsumeContext<AddCustomerMessage> context)
    {
        const string sql = "INSERT INTO Customer (Id, Name) VALUES (@Id, @Name);";

        _dbConnection.Execute(sql, context.Message);

        return Task.CompletedTask;
    }
}