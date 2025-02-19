using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Repositories.Interfaces
{
    public interface IStateRepository : IBaseRepository<State>
    {
        Task<State> GetByDescriptionAsync(string description);
    }
}
