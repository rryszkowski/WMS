using System.Data;
using Dapper;
using MediatR;

namespace WMS.Application.Inventory.Queries;

public class GetInventorySummaryHandler : IRequestHandler<GetInventorySummaryQuery, IEnumerable<InventorySummaryResponse>>
{
    private readonly IDbConnection _connection;

    public GetInventorySummaryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<InventorySummaryResponse>> Handle(
        GetInventorySummaryQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = "SELECT * FROM InventoryView";

        var result = await _connection.QueryAsync<InventorySummaryResponse>(sql);

        return result;
    }
}