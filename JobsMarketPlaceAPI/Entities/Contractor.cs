using System.ComponentModel.DataAnnotations;

namespace JobsMarketPlaceAPI.Entities
{
    public class Contractor
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 5)]
        public decimal Rating { get; set; }
    }
}
