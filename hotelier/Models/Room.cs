

using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Room {

        [Key]
        [Required]
        public int Id {get; set;}

        [Key]
        [Required]
        public int HotelId {get; set;}

        [Required]
        public int capacity {get; set;}

        [Required]
        public string description {get; set;}

        [Required]
        public string type {get; set;}

    }
}

