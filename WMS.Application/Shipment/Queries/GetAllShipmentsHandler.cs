using System.Data;
using Dapper;
using MediatR;

namespace WMS.Application.Shipment.Queries;

public class GetAllShipmentsHandler : IRequestHandler<GetAllShipmentsQuery, IEnumerable<ShipmentResponse>>
{
    private readonly IDbConnection _connection;

    public GetAllShipmentsHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<ShipmentResponse>> Handle(
        GetAllShipmentsQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = "SELECT * FROM ShipmentView";

        var result = await _connection.QueryAsync<ShipmentResponse>(sql);

        return result;
    }
}