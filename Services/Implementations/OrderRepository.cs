
using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private IApplicationDbContext _context;

        public OrderRepository(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Order entity)
        {
            if (!await ExistsAsync(entity.Id))
            {
                await _context.Orders.AddAsync(entity);
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var row = await _context.Orders.FindAsync(id);

            if (row != null)
            {
                await _context.Orders.Where(a => a.Id == id).ExecuteDeleteAsync();
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Orders.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
