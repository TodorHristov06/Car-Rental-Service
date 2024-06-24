using System.ComponentModel.DataAnnotations;

namespace CarPal.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string DriverLicenseNumber { get; set; }
    }
}
