using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Repositories.Interfaces
{
    public interface IAssetTypeRepository : IBaseRepository<AssetType>
    {
        Task<AssetType> GetByNameAsync(string description);
    }
}
