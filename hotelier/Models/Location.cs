
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Location {
       [Key]
        public int Id {get; set;}

       [Required]
        public string loc {get; set;}
    }
}