namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IBaseRepository<T> : ICrudRepository<T>
    {
        Task<bool> ExistsAsync(string name);
    }
}
