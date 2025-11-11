using ElectronicsEshop.Application.Products.DTOs;
using MediatR;

namespace ElectronicsEshop.Application.Products.Queries.GetProduct;

public sealed class GetProductQuery : IRequest<ProductDetailDto>
{
    public int Id { get; init; }
}