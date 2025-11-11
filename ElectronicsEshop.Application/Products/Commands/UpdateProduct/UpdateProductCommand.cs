using ElectronicsEshop.Application.Products.Shared.DTOs;
using MediatR;

namespace ElectronicsEshop.Application.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public required ProductUpsertDto Data { get; set; }
}
