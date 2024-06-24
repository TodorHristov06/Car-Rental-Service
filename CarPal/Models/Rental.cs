using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarPal.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalCost { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
