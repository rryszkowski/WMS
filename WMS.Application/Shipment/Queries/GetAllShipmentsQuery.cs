using MediatR;

namespace WMS.Application.Shipment.Queries;

public sealed record GetAllShipmentsQuery : IRequest<IEnumerable<ShipmentResponse>>;