using System.ComponentModel.DataAnnotations;

namespace JobsMarketPlaceAPI.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
    }
}
