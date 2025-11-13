namespace ElectronicsEshop.Domain.RepositoryInterfaces;

public interface ICartItemRepository
{
    Task<bool> ExistsForProductAsync(int productId, CancellationToken cancellationToken);
}
