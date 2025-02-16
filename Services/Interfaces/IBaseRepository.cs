namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById();
        Task<T> GetByNameAsync(string name);
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(string name);
    }
}
