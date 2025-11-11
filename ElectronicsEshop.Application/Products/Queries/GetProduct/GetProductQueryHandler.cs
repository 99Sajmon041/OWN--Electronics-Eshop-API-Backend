using AutoMapper;
using ElectronicsEshop.Application.Exceptions;
using ElectronicsEshop.Application.Products.DTOs;
using ElectronicsEshop.Domain.Entities;
using ElectronicsEshop.Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElectronicsEshop.Application.Products.Queries.GetProduct;

public sealed class GetProductQueryHandler(
    ILogger<GetProductQueryHandler> logger,
    IProductRepository productRepository,
    IMapper mapper) : IRequestHandler<GetProductQuery, ProductDetailDto>
{
    public async Task<ProductDetailDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Získání produktu s ID: {@Request}", request.Id);

        var entity = await productRepository.GetByIdWithCategoryAsync(request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(Product), request.Id);

        var product = mapper.Map<ProductDetailDto>(entity);

        return product;
    }
}
