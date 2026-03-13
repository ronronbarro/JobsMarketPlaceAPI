using JobsMarketPlaceAPI.Entities;

namespace JobsMarketPlaceAPI.Services
{
    public interface IJobService
    {
        Task<Job> CreateAsync(Job job);
    }
}
