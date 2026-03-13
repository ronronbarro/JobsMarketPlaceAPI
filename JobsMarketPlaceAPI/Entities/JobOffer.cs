using System.ComponentModel.DataAnnotations;

namespace JobsMarketPlaceAPI.Entities
{
    public class JobOffer
    {
        public Guid Id { get; set; }

        public Guid JobId { get; set; }

        public Guid ContractorId { get; set; }

        [Range(1, 100000000)]
        public decimal Price { get; set; }

        public bool IsAccepted { get; set; }
    }
}
