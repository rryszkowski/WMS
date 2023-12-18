using System.Data;
using Dapper;
using MediatR;

namespace WMS.Application.Product.Queries;

public class GetProductSummaryHandler : IRequestHandler<GetProductSummaryQuery, IEnumerable<ProductSummaryResponse>>
{
    private readonly IDbConnection _connection;

    public GetProductSummaryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<ProductSummaryResponse>> Handle(
        GetProductSummaryQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = "SELECT * FROM ProductSummary";

        var result = await _connection.QueryAsync<ProductSummaryResponse>(sql);

        return result;
    }
}