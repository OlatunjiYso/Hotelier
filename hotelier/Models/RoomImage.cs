using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class RoomImage {

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public string Url { get; set; }

    }
}
