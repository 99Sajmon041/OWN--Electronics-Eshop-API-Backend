using ElectronicsEshop.Application.Common.Enums;
using ElectronicsEshop.Application.Common.Pagination;
using ElectronicsEshop.Application.Products.DTOs;
using MediatR;

namespace ElectronicsEshop.Application.Products.Queries.GetProducts;

public sealed class GetProductsQuery : IRequest<PagedResult<ProductListItemDto>>
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 20;
    public string? Sort { get; init; } = "name";
    public SortOrder Order { get; init; } = SortOrder.Asc;
    public int? CategoryId { get; init; }
    public bool? IsActive { get; init; }
    public decimal? PriceMin { get; init; }
    public decimal? PriceMax { get; init; }
    public int? StockMin { get; init; }
    public int? StockMax { get; init; }
    public string? Q { get; init; }
}
