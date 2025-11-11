using ElectronicsEshop.Application.Products.Shared.DTOs;
using FluentValidation;

namespace ElectronicsEshop.Application.Products.Shared.Validators;

public sealed class ProductUpsertValidator : AbstractValidator<ProductUpsertDto>
{
    public ProductUpsertValidator()
    {
        RuleFor(p => p.ProductCode)
            .NotEmpty().WithMessage("ProductCode je povinný.")
            .MaximumLength(20).WithMessage("ProductCode může mít max 20 znaků.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Název je povinný.")
            .Length(2, 100).WithMessage("Název musí mít 2–100 znaků.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Popis je povinný.")
            .Length(2, 2000).WithMessage("Popis musí mít 2–2000 znaků.");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId musí být kladné číslo.");

        RuleFor(p => p.Price)
            .InclusiveBetween(0.01m, 999_999.99m)
            .WithMessage("Cena musí být v rozmezí 0.01 až 999999.99.");

        RuleFor(p => p.DiscountPercentage)
            .InclusiveBetween(0, 90)
            .WithMessage("Sleva musí být v rozmezí 0–90 %.");

        RuleFor(p => p.StockQty)
            .InclusiveBetween(0, 100_000)
            .WithMessage("Množství skladem musí být v rozmezí 0–100000.");

        RuleFor(p => p.ImageUrl).NotEmpty()
            .WithMessage("Obrázek je povinný.");

        RuleFor(p => p)
            .Must(p => p.Price * (1 - p.DiscountPercentage / 100m) >= 0.01m)
            .WithMessage("Výsledná cena po slevě musí být alespoň 0.01.");
    }
}
