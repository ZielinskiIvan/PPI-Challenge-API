using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Services.Implementations
{
    public class StateRepository : IStateRepository
    {
        private IApplicationDbContext _context;

        public StateRepository(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(State entity)
        {
            if (!await ExistsAsync(entity.Description))
            {
                await _context.States.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(ExceptionUtilities.AlreadyExitsError);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var row = await _context.States.FindAsync(id);

            if (row != null)
            {
                await _context.States.Where(a => a.Id == id).ExecuteDeleteAsync();
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string description)
        {
            return await _context.States.Where(e => e.Description == description).AnyAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.States.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await _context.States.FindAsync(id);
        }

        public async Task<State> GetByNameAsync(string description)
        {
            return await _context.States.Where(e => e.Description == description).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(State entity)
        {
            _context.States.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
