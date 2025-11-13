using ElectronicsEshop.Application.Exceptions;
using ElectronicsEshop.Domain.Entities;
using ElectronicsEshop.Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProductsStockQty;

public sealed class UpdateProductsStockQtyCommandHandler(IProductRepository productRepository,
    ILogger<UpdateProductsStockQtyCommandHandler> logger) : IRequestHandler<UpdateProductsStockQtyCommand>
{
    public async Task Handle(UpdateProductsStockQtyCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Product), request.Id);

        await productRepository.AddStockQtyAsync(product, request.StockQty, cancellationToken);

        logger.LogInformation(
            "Produkt {ProductName} s ID {ProductId} byl doskladněn o {Amount} ks. Aktuálně skladem: {StockQty}",
            product.Name, product.Id, request.StockQty, product.StockQty);
    }
}
