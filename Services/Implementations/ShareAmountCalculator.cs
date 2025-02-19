using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Repositories.Interfaces;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class ShareAmountCalculator : IShareAmountCalculator
    {
        private readonly IAssetRepository _assetRepository;
        private readonly ICommissionTaxRepository _commissionTaxRepository;
        public ShareAmountCalculator(IAssetRepository assetRepository, ICommissionTaxRepository commissionTaxRepository)
        {
            _assetRepository = assetRepository;
            _commissionTaxRepository = commissionTaxRepository;
        }

        public async Task<double> GetTotalAmountAsync(int quanity, Asset asset, double? price = null)
        {
            CommissionTax commissionTax = await _commissionTaxRepository.GetCommissionTaxByAssetTypeIdAsync(asset.AssetTypeID);
            double totalAmount = asset.UnitPrice * quanity;
            double commission = totalAmount * commissionTax.Commission;
            double tax = commission * commissionTax.Tax;

            return totalAmount + commission + tax;
        }
    }
}
