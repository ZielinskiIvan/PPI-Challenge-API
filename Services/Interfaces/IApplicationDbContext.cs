using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Error> Errors { get; }
        DbSet<AssetType> AssetTypes { get; }

        public DbSet<State> States { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
