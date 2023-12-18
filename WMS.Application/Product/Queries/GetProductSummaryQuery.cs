using MediatR;

namespace WMS.Application.Product.Queries;

public sealed record GetProductSummaryQuery : IRequest<IEnumerable<ProductSummaryResponse>>;