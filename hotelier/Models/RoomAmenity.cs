using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {
    public class RoomAmenity {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Url { get; set; } 
        public Room Room { get; set; }
    }
}