using JobsMarketPlaceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsMarketPlaceAPI.Controllers
{    
    [ApiController]
    public class CustomerController(ICustomerRepository repo) : ControllerBase
    {
        [HttpGet("customers/{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await repo.SearchAsync(query);
            return Ok(result);
        }
    }


}
