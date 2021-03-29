using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class HotelAmenity {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public bool AirportShuttle { get; set; }
        public bool FitnessCentre { get; set; }
        public bool Spa { get; set; }
        public bool ParkingSpace { get; set; }
        public bool Restuarant { get; set; } 
        public bool SmokingArea { get; set; }
        public bool Bar { get; set; }
        public Hotel Hotel { get; set; }
    }
}