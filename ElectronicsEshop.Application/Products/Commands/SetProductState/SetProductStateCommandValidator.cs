using FluentValidation;

namespace ElectronicsEshop.Application.Products.Commands.SetProductState;

public sealed class SetProductStateCommandValidator : AbstractValidator<SetProductStateCommand>
{
    public SetProductStateCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0);
    }
}
