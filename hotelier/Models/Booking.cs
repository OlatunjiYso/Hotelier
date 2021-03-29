using System;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Booking {
        public int Id { get; set; }
        public int userId { get; set; }
        public int roomId { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public bool active { get; set;  }

        User User { get; set; }
        Hotel Room {get; set; }

    }
}