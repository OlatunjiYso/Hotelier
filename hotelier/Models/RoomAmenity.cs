using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class RoomAmenity {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public string Url { get; set; } 

    }
}