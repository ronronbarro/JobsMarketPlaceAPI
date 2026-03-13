using JobsMarketPlaceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsMarketPlaceAPI.Controllers
{   
    [ApiController]   
    public class ContractorController(IContractorRepository repo) : ControllerBase
    {
        [HttpGet("contractors/{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await repo.SearchAsync(query);
            return Ok(result);
        }
    }
}
