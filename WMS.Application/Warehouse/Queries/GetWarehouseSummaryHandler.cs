using System.Data;
using Dapper;
using MediatR;

namespace WMS.Application.Warehouse.Queries;

public class GetWarehouseSummaryHandler : IRequestHandler<GetWarehouseSummaryQuery, IEnumerable<WarehouseSummaryResponse>>
{
    private readonly IDbConnection _connection;

    public GetWarehouseSummaryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<WarehouseSummaryResponse>> Handle(
        GetWarehouseSummaryQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = "SELECT * FROM WarehouseSummary";

        var result = await _connection.QueryAsync<WarehouseSummaryResponse>(sql);

        return result;
    }
}