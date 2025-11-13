using FluentValidation;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProductDiscount;

public sealed class UpdateProductDiscountCommandValidator : AbstractValidator<UpdateProductDiscountCommand>
{
    public UpdateProductDiscountCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0);

        RuleFor(p => p.DiscountPercentage)
            .InclusiveBetween(0, 90)
            .WithMessage("Sleva musí být v rozmezí 0–90 %.");
    }
}
