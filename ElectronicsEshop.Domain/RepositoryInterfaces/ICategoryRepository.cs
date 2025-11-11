namespace ElectronicsEshop.Domain.RepositoryInterfaces;

public interface ICategoryRepository
{
    Task<bool> Exists(int id, CancellationToken ct);
}
