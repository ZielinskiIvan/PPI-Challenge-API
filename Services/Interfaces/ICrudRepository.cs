using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface ICrudRepository<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
    }
}
