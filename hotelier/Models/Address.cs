using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Address {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int hotelId { get; set; }

        [Required]
        public string location { get; set; }

    }
}