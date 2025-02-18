using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Services.Implementations
{
    public class AssetRepository : IAssetRepository
    {
        private IApplicationDbContext _context;

        public AssetRepository(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Asset entity)
        {
            if (!await ExistsAsync(entity.Name))
            {
                await _context.Assets.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var row = await _context.Assets.FindAsync(id);

            if (row != null)
            {
                await _context.Assets.Where(a => a.Id == id).ExecuteDeleteAsync();
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Assets.Where(e => e.Name == name).AnyAsync();
        }

        public async Task<bool> ExistsByTickerAsync(string ticker)
        {
            return await _context.Assets.Where(e => e.Ticker == ticker).AnyAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Assets.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<List<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset> GetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task UpdateAsync(Asset entity)
        {
            _context.Assets.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
