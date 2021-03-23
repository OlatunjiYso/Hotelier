using System;
using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Booking {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public int roomId { get; set; }

        [Required]
        public DateTime from { get; set; }

        [Required]
        public DateTime to { get; set; }

        [Required]
        public bool active { get; set;  }

    }
}