using JobsMarketPlaceAPI.Entities;

namespace JobsMarketPlaceAPI.Repositories
{
    public interface IContractorRepository
    {
        Task<IEnumerable<Contractor>> SearchAsync(string query);
    }
}
