using JobsMarketPlaceAPI.Entities;
using JobsMarketPlaceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsMarketPlaceAPI.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class JobController(IJobRepository repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Job job)
        {
            if (job == null)
                return BadRequest("Job is required.");

            if (job.DueDate <= job.StartDate)
                return BadRequest("DueDate must be later than StartDate.");

            if (job.Budget <= 0)
                return BadRequest("Budget must be greater than zero.");

            var createdJob = await repo.AddAsync(job);

            return CreatedAtAction(nameof(GetById), new { id = createdJob.Id }, createdJob);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var job = await repo.GetByIdAsync(id);

            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 50)
        {
            var jobs = await repo.GetAllAsync(page, pageSize);
            return Ok(jobs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingJob = await repo.GetByIdAsync(id);

            if (existingJob == null)
                return NotFound();

            await repo.DeleteAsync(id);

            return NoContent();
        }

    }
}
