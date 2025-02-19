using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Repositories.Interfaces
{
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        Task<bool> ExistsByTickerAsync(string ticker);
    }
}
