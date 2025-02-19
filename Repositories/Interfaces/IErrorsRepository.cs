using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Repositories.Interfaces
{
    public interface IErrorsRepository
    {
        Task<List<Error>> GetAllAsync();
        Task CreateAsync(Error entity);
    }
}
