using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> , IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                builder.Entity<IdentityRole>(entity =>
                {
                    entity.Property(e => e.Id).HasColumnType("NVARCHAR(450)");
                });
            }
            else if (Database.ProviderName == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                builder.Entity<IdentityRole>(entity =>
                {
                    entity.Property(e => e.Id).HasColumnType("TEXT");
                });
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Error> Errors { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<State> States { get; set; }
    }
}
