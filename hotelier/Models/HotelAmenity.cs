using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class HotelAmenity {

       [Key]
       [Required]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public bool AirportShuttle { get; set; }

        [Required]
        public bool FitnessCentre { get; set; }

        [Required]
        public bool Spa { get; set; }

        [Required]
        public bool ParkingSpace { get; set; }

        [Required]
        public bool Restuarant { get; set; } 

        [Required]
        public bool SmokingArea { get; set; }

        [Required]
        public bool Bar { get; set; }
    }
}