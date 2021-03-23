

using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class User {

        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        [MaxLength(50)]
        public string firstname {get; set;}

        [Required]
        [MaxLength(50)]
        public string lastname {get; set;}

        [Required]
        [MaxLength(50)]
        public string email {get; set;}

        [Required]
        public string password { get;}

        [Required]
        public string role {get; set;}
    }
}
