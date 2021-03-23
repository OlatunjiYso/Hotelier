using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Favourite {

        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        public int HotelId {get; set;}

         [Required]
         public int UserId {get; set;}
         
    }
}