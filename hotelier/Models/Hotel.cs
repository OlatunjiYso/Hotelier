using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Hotel {

        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        [MaxLength(50)]
        public string email {get; set;}

        [Required]
        [MaxLength(250)]
        public string about {get; set;}
        
        [MaxLength(80)]
       public string motto {get; set;}
    }
}