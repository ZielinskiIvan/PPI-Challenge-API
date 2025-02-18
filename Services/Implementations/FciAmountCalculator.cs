using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class FciAmountCalculator : IFciAmountCalculator
    {
        public async Task<double> GetTotalAmountAsync(int quanity, Asset asset, double? price = null)
        {
            return asset.UnitPrice * quanity;
        }
    }
}
