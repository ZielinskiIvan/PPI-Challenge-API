using Microsoft.EntityFrameworkCore;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Repositories.Interfaces;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Repositories.Implementations
{
    public class ErrorsRepository : IErrorsRepository
    {

        private IApplicationDbContext _context;

        public ErrorsRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Error entity)
        {
            await _context.Errors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Error>> GetAllAsync()
        {
            return await _context.Errors.ToListAsync();
        }
    }
}
