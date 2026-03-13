using JobsMarketPlaceAPI.Entities;

namespace JobsMarketPlaceAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> SearchAsync(string query);
    }
}
