using JobsMarketPlaceAPI.Data;
using JobsMarketPlaceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsMarketPlaceAPI.Repositories
{
    public class CustomerRepository(MarketplaceDbContext db) : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> SearchAsync(string query)
        {
            IQueryable<Customer> customers = db.Customers.AsNoTracking();

            if (Guid.TryParse(query, out var customerId))
            {
                customers = customers.Where(x => x.Id == customerId);
            }
            else
            {
                customers = customers.Where(x => x.LastName.Contains(query));
            }

            return await customers.ToListAsync();
        }

    }
}
