using AutoMapper;
using ElectronicsEshop.Application.Exceptions;
using ElectronicsEshop.Domain.Entities;
using ElectronicsEshop.Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElectronicsEshop.Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger,
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if(!await categoryRepository.Exists(request.Data.CategoryId, cancellationToken))
            throw new NotFoundException(nameof(Category), request.Data.CategoryId);

        if (await productRepository.ExistsByProductCodeAsync(request.Data.ProductCode, cancellationToken))
            throw new ConflictException(request.Data.ProductCode, nameof(Product));

        var product = mapper.Map<Product>(request.Data);
        int productId = await productRepository.AddAsync(product, cancellationToken);

        logger.LogInformation("Produkt {ProductName} byl zařazen.", request.Data.Name);

        return productId;
    }
}
