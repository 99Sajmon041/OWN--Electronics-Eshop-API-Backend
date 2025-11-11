using ElectronicsEshop.Domain.RepositoryInterfaces;
using ElectronicsEshop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsEshop.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<bool> Exists(int id, CancellationToken ct = default)
    {
        return await context.Categories.AnyAsync(c => c.Id == id, ct);
    }
}
