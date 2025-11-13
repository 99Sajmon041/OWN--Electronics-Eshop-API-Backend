using MediatR;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProductDiscount;

public sealed class UpdateProductDiscountCommand : IRequest
{
    public int Id { get; set; }
    public decimal DiscountPercentage { get; set; }
}
