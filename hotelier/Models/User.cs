

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {
    public class User {
        public int Id {get; set;}
        public string Firstname {get; set;}
        public string Lastname {get; set;}
        public string Email {get; set;}
        public string Password { get; set;}
        public string Role {get; set;}

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
