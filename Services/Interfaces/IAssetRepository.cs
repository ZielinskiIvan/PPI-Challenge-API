using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        Task<bool> ExistsByTickerAsync(string ticker);
    }
}
