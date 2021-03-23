using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Message {

        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        public int HotelId {get; set;}

        [Required]
        public int WriterId {get; set;}

        [Required]
        [MaxLength(400)]
        public string Msg {get; set;}
    }
}