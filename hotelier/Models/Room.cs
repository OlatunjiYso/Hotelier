using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Room {
        public int Id {get; set;}

        public int HotelId {get; set;}
        public int Capacity {get; set;}
        public string Description {get; set;}
        public string Type {get; set;}
        public Hotel Hotel { get; set; }
        public RoomAmenity Amenities { get; set; }
        public ICollection<RoomImage>  Images { get; set; }   
        public ICollection<Booking>  Bookings { get; set; }
    }
}

