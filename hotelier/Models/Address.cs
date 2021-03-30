using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Address {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Location { get; set; }
        public Hotel Hotel { get; set; }
    }
}