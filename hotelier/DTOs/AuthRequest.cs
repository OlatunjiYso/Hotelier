using System.ComponentModel.DataAnnotations;

namespace hotelier.DTOs {

    public class AuthRequest {

        [Required]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
    }
}
