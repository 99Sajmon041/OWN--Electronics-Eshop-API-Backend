using FluentValidation;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProductsStockQty;

public sealed class UpdateProductsStockQtyCommandValidator : AbstractValidator<UpdateProductsStockQtyCommand>
{
    public UpdateProductsStockQtyCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0);

        RuleFor(p => p.StockQty)
            .GreaterThan(0)
            .WithMessage("Počet kusů pro doskladnění musí být větší než 0.");
    }
}
