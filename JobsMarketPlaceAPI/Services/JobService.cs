using JobsMarketPlaceAPI.Entities;
using JobsMarketPlaceAPI.Repositories;

namespace JobsMarketPlaceAPI.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _repo;

        public JobService(IJobRepository repo)
        {
            _repo = repo;
        }

        public async Task<Job> CreateAsync(Job job)
        {
            if (job.DueDate <= job.StartDate)
                throw new Exception("DueDate must be later than StartDate");

            return await _repo.AddAsync(job);
        }
    }

}
