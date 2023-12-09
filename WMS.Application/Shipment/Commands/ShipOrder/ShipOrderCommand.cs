using MediatR;

namespace WMS.Application.Shipment.Commands.ShipOrder;

public record ShipOrderCommand(ShipOrderRequest Dto) : IRequest<Guid>;