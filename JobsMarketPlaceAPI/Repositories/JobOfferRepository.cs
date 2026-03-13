using JobsMarketPlaceAPI.Data;
using JobsMarketPlaceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsMarketPlaceAPI.Repositories
{
    public class JobOfferRepository(MarketplaceDbContext db) : IJobOfferRepository
    {
        public async Task<JobOffer> AddAsync(JobOffer offer)
        {
            await db.JobOffers.AddAsync(offer);
            await db.SaveChangesAsync();
            return offer;
        }

        public async Task<JobOffer?> GetByIdAsync(Guid id)
        {
            return await db.JobOffers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<JobOffer>> GetByJobIdAsync(Guid jobId)
        {
            return await db.JobOffers
                .AsNoTracking()
                .Where(x => x.JobId == jobId)
                .OrderBy(x => x.Price)
                .ToListAsync();
        }

        public async Task UpdateAsync(JobOffer offer)
        {
            db.JobOffers.Update(offer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var offer = await db.JobOffers.FindAsync(id);

            if (offer == null)
                return;

            db.JobOffers.Remove(offer);
            await db.SaveChangesAsync();
        }
    }

}
