using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class HotelImage {
        public int Id { get; set; }
        public int hotelId { get; set; }
        public string url { get; set; }
        public Hotel Hotel { get; set; }

    }
}