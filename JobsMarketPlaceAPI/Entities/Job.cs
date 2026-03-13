using System.ComponentModel.DataAnnotations;

namespace JobsMarketPlaceAPI.Entities
{
    public class Job
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        [Range(1, 100000000)]
        public decimal Budget { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public Guid CustomerId { get; set; }

        public Guid? AcceptedByContractorId { get; set; }

        public ICollection<JobOffer>? Offers { get; set; }
    }
}
