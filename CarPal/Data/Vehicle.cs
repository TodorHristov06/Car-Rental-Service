using System.ComponentModel.DataAnnotations;

namespace CarPal.Data
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}
