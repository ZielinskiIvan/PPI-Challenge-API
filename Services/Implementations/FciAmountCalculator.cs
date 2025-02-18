using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class FciAmountCalculator : IFciAmountCalculator
    {
        public async Task<decimal> GetTotalAmountAsync(int quanity, Asset asset, decimal? price = null)
        {
            return price.Value * quanity;
        }
    }
}
