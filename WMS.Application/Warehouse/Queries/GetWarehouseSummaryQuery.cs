using MediatR;

namespace WMS.Application.Warehouse.Queries;

public sealed record GetWarehouseSummaryQuery : IRequest<IEnumerable<WarehouseSummaryResponse>>;