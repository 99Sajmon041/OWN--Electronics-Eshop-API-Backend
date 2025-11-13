using MediatR;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProductsStockQty;

public sealed class UpdateProductsStockQtyCommand : IRequest
{
    public int Id { get; set; }
    public int StockQty { get; set; }
}
