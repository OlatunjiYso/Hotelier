using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Address {
        public int Id { get; set; }
        public int hotelId { get; set; }
        public string location { get; set; }
        public Hotel Hotel { get; set; }
    }
}