using hotelier.Models;

namespace hotelier.DTOs {

    class AuthResponse {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set;}
        public string Email { get; set; }
        public string Token {get; set;}

         public AuthResponse(User user, string token) {
        Id = user.Id;
        Lastname = user.Lastname;
        Firstname = user.Firstname;
        Email = user.Email;
        Token = token;
    }
    }

   
}