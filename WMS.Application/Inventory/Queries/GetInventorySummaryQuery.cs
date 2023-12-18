using MediatR;

namespace WMS.Application.Inventory.Queries;

public record GetInventorySummaryQuery() : IRequest<IEnumerable<InventorySummaryResponse>>;