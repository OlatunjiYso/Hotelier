
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Review {
        public int Id {get; set;}
        public int HotelId { get; set; }
        public int ReviewerId { get; set; }
        public string Msg { get; set; }
        public User Reviewer { get; set; }
        public Hotel Hotel { get; set; }
    }
}