using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface ICommissionTaxRepository
    {
        Task<CommissionTax> GetCommissionTaxByAssetTypeIdAsync(int assetTypeId);
    }
}
