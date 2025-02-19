namespace PPI_Challenge_API.Repositories.Interfaces
{
    public interface IBaseRepository<T> : ICrudRepository<T>
    {
        Task<bool> ExistsAsync(string name);
    }
}
