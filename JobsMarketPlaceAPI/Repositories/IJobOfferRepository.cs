using JobsMarketPlaceAPI.Entities;

namespace JobsMarketPlaceAPI.Repositories
{
    public interface IJobOfferRepository
    {
        Task<JobOffer> AddAsync(JobOffer offer);
        Task<JobOffer?> GetByIdAsync(Guid id);
        Task<IEnumerable<JobOffer>> GetByJobIdAsync(Guid jobId);
        Task UpdateAsync(JobOffer offer);
        Task DeleteAsync(Guid id);
    }

}
