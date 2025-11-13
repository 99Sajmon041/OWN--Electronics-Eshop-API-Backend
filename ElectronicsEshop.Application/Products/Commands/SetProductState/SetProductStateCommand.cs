using MediatR;

namespace ElectronicsEshop.Application.Products.Commands.SetProductState;

public sealed class SetProductStateCommand : IRequest
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}
