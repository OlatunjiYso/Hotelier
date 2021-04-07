

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotelier.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
