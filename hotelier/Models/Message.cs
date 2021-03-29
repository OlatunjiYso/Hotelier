using System.ComponentModel.DataAnnotations;

namespace hotelier.Models {

    public class Message {
        public int Id {get; set;}

        public int HotelId {get; set;}

        public int WriterId {get; set;}
        public string Msg {get; set;}

        public User Writer { get; set; }
        public Hotel Hotel { get; set; }
    }
}