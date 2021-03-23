using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class HotelImage {

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int hotelId { get; set; }

        [Required]
        public string url { get; set; }

    }
}