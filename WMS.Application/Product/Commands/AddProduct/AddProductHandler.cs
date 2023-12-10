﻿using MediatR;
using WMS.Infrastructure.Database.Write.UnitOfWork;

namespace WMS.Application.Product.Commands.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async  Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var product = new Domain.Entities.Product
        {
            Category = dto.Category,
            Manufacturer = dto.Manufacturer,
            Name = dto.Name
        };

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return product.Id;
    }
}