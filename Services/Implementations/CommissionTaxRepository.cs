using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class CommissionTaxRepository : ICommissionTaxRepository
    {
        private IApplicationDbContext _context;

        public CommissionTaxRepository(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<CommissionTax> GetCommissionTaxByAssetTypeIdAsync(int assetTypeId)
        {
            return await _context.CommissionTaxes
                       .FirstOrDefaultAsync(ct => ct.AssetTypeId == assetTypeId);
        }
    }
}
