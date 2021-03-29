using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Favourite {
        public int Id {get; set;}
        public int HotelId {get; set;}
        public int UserId {get; set;}
        public User User { get; set; }
        public Hotel Hotel { get; set; }
    }
}