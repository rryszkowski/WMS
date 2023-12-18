using MediatR;

namespace WMS.Application.Inventory.Queries;

public sealed record GetInventorySummaryQuery() : IRequest<IEnumerable<InventorySummaryResponse>>;