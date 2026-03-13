using JobsMarketPlaceAPI.Data;
using JobsMarketPlaceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsMarketPlaceAPI.Repositories
{
    public class JobRepository(MarketplaceDbContext db) : IJobRepository
    {
        public async Task<Job> AddAsync(Job job)
        {
            await db.Jobs.AddAsync(job);
            await db.SaveChangesAsync();
            return job;
        }

        public async Task<Job?> GetByIdAsync(Guid id)
        {
            return await db.Jobs
                .AsNoTracking()
                .Include(x => x.Offers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Job>> GetAllAsync(int page = 1, int pageSize = 50)
        {
            return await db.Jobs
                .AsNoTracking()
                .OrderByDescending(x => x.StartDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateAsync(Job job)
        {
            db.Jobs.Update(job);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var job = await db.Jobs.FindAsync(id);

            if (job == null)
                return;

            db.Jobs.Remove(job);
            await db.SaveChangesAsync();
        }
    }

}
