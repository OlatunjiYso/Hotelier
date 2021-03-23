
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Review {

        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        public int HotelId { get; set; }

        [Required]
        public int ReviewerId { get; set; }

        [Required]
        [MaxLength(400)]
        public string Msg { get; set; }

    }
}