using ElectronicsEshop.Application.Exceptions;
using ElectronicsEshop.Domain.Entities;
using ElectronicsEshop.Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElectronicsEshop.Application.Products.Commands.DeleteProduct;

public sealed class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,
    IProductRepository productRepository,
    IOrderItemRepository orderItemRepository,
    ICartItemRepository cartItemRepository) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Product), request.Id);

        if(await orderItemRepository.ExistsForProductAsync(product.Id, cancellationToken))
            throw new DomainException($"Produkt nelze smazat – je použit v objednávkách.");

        if(await cartItemRepository.ExistsForProductAsync(product.Id, cancellationToken))
            throw new DomainException($"Produkt nelze smazat – mají ho uživatelé v košíku.");

        await productRepository.DeleteAsync(request.Id, cancellationToken);
        logger.LogInformation("Produkt {ProductId} ({ProductName}) byl odstraněn.", product.Id, product.Name);
    }
}
