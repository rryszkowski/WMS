using System.Data;
using Dapper;
using MediatR;

namespace WMS.Application.Order.Queries;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderResponse>>
{
    private readonly IDbConnection _connection;

    public GetAllOrdersHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<OrderResponse>> Handle(
        GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = "SELECT * FROM OrderView";

        var result = await _connection.QueryAsync<OrderResponse>(sql);

        return result;
    }
}