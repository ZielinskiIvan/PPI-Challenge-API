using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Error> Errors { get; }
        DbSet<AssetType> AssetTypes { get; }
        DbSet<State> States { get; }
        DbSet<Asset> Assets { get; }
        DbSet<CommissionTax> CommissionTaxes { get; }

        DbSet<Order> Orders { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
