using ElectronicsEshop.Application.Exceptions;
using ElectronicsEshop.Domain.Entities;
using ElectronicsEshop.Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProductDiscount;

public sealed class UpdateProductDiscountCommandHandler(IProductRepository productRepository,
    ILogger<UpdateProductDiscountCommandHandler> logger) : IRequestHandler<UpdateProductDiscountCommand>
{
    public async Task Handle(UpdateProductDiscountCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(Product), request.Id);

        await productRepository.UpdateDiscountAsync(product, request.DiscountPercentage, cancellationToken);

        logger.LogInformation("Sleva produktu {ProductName} s ID {ProductId} byla aktualizována na hodnotu {ProductDiscount}",
            product.Name, product.Id, request.DiscountPercentage);
    }
}
