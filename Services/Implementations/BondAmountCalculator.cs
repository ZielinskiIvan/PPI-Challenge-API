using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class BondAmountCalculator : IBondAmountCalculator
    {
        private readonly IAssetRepository _assetRepository;
        private readonly ICommissionTaxRepository _commissionTaxRepository;
        public BondAmountCalculator(IAssetRepository assetRepository, ICommissionTaxRepository commissionTaxRepository)
        {
            _assetRepository = assetRepository;
            _commissionTaxRepository = commissionTaxRepository;
        }

        public async Task<decimal> GetTotalAmountAsync(int quanity, Asset asset, decimal? price = null)
        {
            CommissionTax commissionTax = await _commissionTaxRepository.GetCommissionTaxByAssetTypeIdAsync(asset.AssetTypeID);
            decimal totalAmount = asset.UnitPrice * quanity;
            decimal commission = totalAmount * commissionTax.Commission;
            decimal tax = commission * commissionTax.Tax;

            return totalAmount + commission + tax;
        }
    }
}
