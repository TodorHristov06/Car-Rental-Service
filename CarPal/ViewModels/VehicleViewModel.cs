using System.ComponentModel.DataAnnotations;

namespace CarPal.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
