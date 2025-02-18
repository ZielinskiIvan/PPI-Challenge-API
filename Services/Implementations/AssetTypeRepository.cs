using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Services.Implementations
{
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private IApplicationDbContext _context;

        public AssetTypeRepository(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(AssetType entity)
        {
            if (!await ExistsAsync(entity.Description))
            {
                await _context.AssetTypes.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var row = await _context.AssetTypes.FindAsync(id);

            if (row != null)
            {
                await _context.AssetTypes.Where(a => a.Id == id).ExecuteDeleteAsync();
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string description)
        {
            return await _context.AssetTypes.Where(e => e.Description == description).AnyAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AssetTypes.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<List<AssetType>> GetAllAsync()
        {
            return await _context.AssetTypes.ToListAsync();
        }

        public async Task<AssetType> GetByIdAsync(int id)
        {
            return await _context.AssetTypes.FindAsync(id);
        }

        public async Task<AssetType> GetByNameAsync(string description)
        {
            return await _context.AssetTypes.Where(e => e.Description == description).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(AssetType entity)
        {
            _context.AssetTypes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
