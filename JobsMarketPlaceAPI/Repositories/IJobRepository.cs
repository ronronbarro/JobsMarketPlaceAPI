using JobsMarketPlaceAPI.Entities;

namespace JobsMarketPlaceAPI.Repositories
{
    public interface IJobRepository
    {
        Task<Job> AddAsync(Job job);
        Task<Job?> GetByIdAsync(Guid id);
        Task<IEnumerable<Job>> GetAllAsync(int page = 1, int pageSize = 50);
        Task UpdateAsync(Job job);
        Task DeleteAsync(Guid id);
    }
}
