using ElectronicsEshop.Domain.RepositoryInterfaces;
using ElectronicsEshop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsEshop.Infrastructure.Repositories;

public sealed class CartItemRepository(AppDbContext db) : ICartItemRepository
{
    public async Task<bool> ExistsForProductAsync(int productId, CancellationToken cancellationToken)
    {
        return await db.CartItems
            .AsNoTracking()
            .AnyAsync(ci => ci.ProductId == productId);
    }
}
