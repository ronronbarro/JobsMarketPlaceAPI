using JobsMarketPlaceAPI.Data;
using JobsMarketPlaceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsMarketPlaceAPI.Repositories
{
    public class ContractorRepository(MarketplaceDbContext db) : IContractorRepository
    {
        public async Task<IEnumerable<Contractor>> SearchAsync(string query)
        {
            IQueryable<Contractor> contractors = db.Contractors.AsNoTracking();

            if (Guid.TryParse(query, out var contractorId))
            {
                contractors = contractors.Where(x => x.Id == contractorId);
            }
            else
            {
                contractors = contractors.Where(x => x.Name.Contains(query));
            }

            return await contractors.ToListAsync();
        }

    }
}
