
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {
    public class Location {
         public int Id {get; set;}
         public int HotelId { get; set; }
        public string loc { get; set;}
        public Hotel Hotel { get; set; }
    }
}