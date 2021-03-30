using System;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Booking {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Active { get; set;  }

        User User { get; set; }
        Hotel Room {get; set; }

    }
}