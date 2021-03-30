using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {
    public class RoomAmenity {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public bool Balcony { get; set; } 
        public bool WaterHeater { get; set; }
        public bool WorkSpace {get; set; }
        public bool Internet {get; set; }
        public Room Room { get; set; }
    }
}