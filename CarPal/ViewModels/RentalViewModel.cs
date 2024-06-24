using System.ComponentModel.DataAnnotations;

namespace CarPal.ViewModels
{
    public class RentalViewModel
    {
        public int RentalId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        public decimal? TotalCost { get; set; }

        public virtual VehicleViewModel Vehicle { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
    }
}
