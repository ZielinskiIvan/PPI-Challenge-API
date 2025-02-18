using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;
using System.Reflection.Emit;

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

            builder.Entity<CommissionTax>()
           .Property(c => c.Commission)
           .HasPrecision(18, 6); 

            builder.Entity<CommissionTax>()
                .Property(c => c.Tax)
                .HasPrecision(18, 6);

            builder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Description = "Acción" },
                new AssetType { Id = 2, Description = "Bono" },
                new AssetType { Id = 3, Description = "FCI" }
            );

            builder.Entity<CommissionTax>().HasData(
                new CommissionTax { Id = 1, AssetTypeId = 1, Commission = 0.006m, Tax = 0.21m },
                new CommissionTax { Id = 2, AssetTypeId = 2, Commission = 0.002m, Tax = 0.21m },
                new CommissionTax { Id = 3, AssetTypeId = 3, Commission = 0.0m, Tax = 0.0m }
            );
            builder.Entity<Asset>().HasData(
                new Asset { Id = 1, Ticker = "AAPL", Name = "Apple", AssetTypeID = 1, UnitPrice = 177.97m },
                new Asset { Id = 2, Ticker = "GOOGL", Name = "Alphabet Inc", AssetTypeID = 1, UnitPrice = 138.21m },
                new Asset { Id = 3, Ticker = "MSFT", Name = "Microsoft", AssetTypeID = 1, UnitPrice = 329.04m },
                new Asset { Id = 4, Ticker = "KO", Name = "Coca Cola", AssetTypeID = 1, UnitPrice = 58.3m },
                new Asset { Id = 5, Ticker = "WMT", Name = "Walmart", AssetTypeID = 1, UnitPrice = 163.42m },
                new Asset { Id = 6, Ticker = "AL30", Name = "BONOS ARGENTINA USD 2030 L.A", AssetTypeID = 2, UnitPrice = 307.4m },
                new Asset { Id = 7, Ticker = "GD30", Name = "Bonos Globales Argentina USD Step Up 2030", AssetTypeID = 2, UnitPrice = 336.1m },
                new Asset { Id = 8, Ticker = "Delta.Pesos", Name = "Delta Pesos Clase A", AssetTypeID = 3, UnitPrice = 0.0181m },
                new Asset { Id = 9, Ticker = "Fima.Premium", Name = "Fima Premium Clase A", AssetTypeID = 3, UnitPrice = 0.0317m }
            );

            builder.Entity<State>().HasData(
                new State { Id = 1, Description = "En proceso" },
                new State { Id = 2, Description = "Ejecutada" },
                new State { Id = 3, Description = "Cancelada" }
            );
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Error> Errors { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CommissionTax> CommissionTaxes { get; set; }
        public DbSet<Order> Orders  { get; set; }
    }
}
