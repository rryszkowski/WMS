using MediatR;

namespace WMS.Application.Product.Commands.AddProduct;

public record AddProductCommand(AddProductRequest Dto) : IRequest<Guid>;