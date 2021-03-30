using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models
{

    public class Hotel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public string Motto { get; set; }
        public Address Address { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<HotelAmenity> Ammenities { get; set; }
        public ICollection<HotelImage> Images { get; set; }
        public ICollection<Location> Location { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}