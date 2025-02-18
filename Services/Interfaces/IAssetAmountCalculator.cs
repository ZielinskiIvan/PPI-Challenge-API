using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IAssetAmountCalculator
    {
        Task<decimal> GetTotalAmountAsync(int quanity,Asset asset, decimal? price = null);
    }
}
