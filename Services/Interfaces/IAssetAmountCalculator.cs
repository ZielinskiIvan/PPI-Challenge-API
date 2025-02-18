using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IAssetAmountCalculator
    {
        Task<double> GetTotalAmountAsync(int quanity,Asset asset, double? price = null);
    }
}
