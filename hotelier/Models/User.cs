

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {
    public class User {
        public int Id {get; set;}
        public string firstname {get; set;}
        public string lastname {get; set;}
        public string email {get; set;}
        public string password { get;}
        public string role {get; set;}

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
