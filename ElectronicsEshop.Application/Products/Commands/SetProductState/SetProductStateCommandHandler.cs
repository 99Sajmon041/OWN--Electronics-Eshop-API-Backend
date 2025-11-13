using ElectronicsEshop.Application.Exceptions;
using ElectronicsEshop.Domain.Entities;
using ElectronicsEshop.Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElectronicsEshop.Application.Products.Commands.SetProductState;

public sealed class SetProductStateCommandHandler(IProductRepository productRepository,
    ILogger<SetProductStateCommandHandler> logger) : IRequestHandler<SetProductStateCommand>
{
    public async Task Handle(SetProductStateCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Product), request.Id);

        await productRepository.SetStateOfProductAsync(product, request.IsActive, cancellationToken);

        string stateOfProduct = request.IsActive ? "aktivní" : "neaktivní";

        logger.LogInformation("Produktu {Productname} s ID: {ProductId} byl nastaven stav jako {StateOfProduct}", 
            product.Name, product.Id, stateOfProduct);
    }
}
