using hotelier.Models;
using System;
using System.Linq;

namespace hotelier.Data
{

    public static class DbInitializer
    {

        public static void Initialize(HotelierContext context)
        {
            context.Database.EnsureCreated();


            if (context.Hotels.Any())
            {
                return; // Db has been seeded
            }
              var users = new User[] {
                new User{ Firstname="John",Lastname="Doe",Email="john@doe.com",Password="pa$$word!",Role="Administrator"},
                new User{ Firstname="Mary",Lastname="Dane",Email="marry@jane.com",Password="pa$$word!",Role="User"},
                new User{ Firstname="Albama",Lastname="Dranne",Email="albama@dranny.com",Password="pa$$word!",Role="User"}
            };
            foreach(User u in users) {
                context.Add(u);
            }
            context.SaveChanges();

             var hotels = new Hotel[] {
                new Hotel { Email="hotel@mail.com", Name="Gallas", Phone="0909090909",About="we are the best", Motto="always the best"},
                new Hotel { Email="hotel2@mail.com", Name="Gallas", Phone="0909090909",About="we are the best", Motto="always the best"},
                new Hotel { Email="hotel3@mail.com", Name="Gallas", Phone="0909090909",About="we are the best", Motto="always the best"}
            };
            foreach(Hotel h in hotels) {
                context.Add(h);
            }
            context.SaveChanges();

            var addresses = new Address[] {
                new Address{ HotelId=1, Location="Plot 2 Ajose"},
                new Address{ HotelId=2, Location="Plot 8 Adeogun"}
            };
            foreach(Address a in addresses) {
                context.Add(a);
            }
            context.SaveChanges();

            var favorites = new Favourite[] {
                new Favourite{ HotelId=1, UserId=1,},
                new Favourite{ HotelId=2, UserId=1,},
                new Favourite{ HotelId=1, UserId=2,}
            };
            foreach(Favourite f in favorites) {
                context.Add(f);
            }
            context.SaveChanges();
           
            var hotelAmenities = new HotelAmenity[] {
                new HotelAmenity { HotelId=1, AirportShuttle=true, FitnessCentre=true, Spa=true, ParkingSpace=true, Restuarant=true, SmokingArea=true, Bar=true},
                new HotelAmenity { HotelId=2, AirportShuttle=true, FitnessCentre=true, Spa=true, ParkingSpace=true, Restuarant=true, SmokingArea=true, Bar=true},
                new HotelAmenity { HotelId=3, AirportShuttle=true, FitnessCentre=true, Spa=true, ParkingSpace=true, Restuarant=true, SmokingArea=true, Bar=true},
            };
            foreach(HotelAmenity a in hotelAmenities) {
                context.Add(a);
            }
            context.SaveChanges();

            var hotelImages = new HotelImage[] {
                new HotelImage { HotelId=1, Url="www.pics/com/1"},
                new HotelImage { HotelId=1, Url="www.pics/com/2"},
                new HotelImage { HotelId=1, Url="www.pics/com/3"},
                new HotelImage { HotelId=2, Url="www.pics/com/4"},
                new HotelImage { HotelId=2, Url="www.pics/com/5"},
                new HotelImage { HotelId=2, Url="www.pics/com/6"}
            };
            foreach( HotelImage i in hotelImages) {
                context.Add(i);
            }
            context.SaveChanges();

            var messages = new Message[] {
                new Message { HotelId=1, WriterId=1, Msg="you are doing fine"},
                 new Message { HotelId=1, WriterId=2, Msg="Hello hotel"}
            };
            foreach(Message m in messages) {
                context.Add(m);
            }
            context.SaveChanges();

            var reviews = new Review[] {
                new Review { HotelId=1, ReviewerId=1, Msg="Nice hotel"},
                new Review { HotelId=1, ReviewerId=1, Msg="Nice hotel"}
            };
            foreach (Review r in reviews) {
                context.Add(r);
            }
            context.SaveChanges();

            var rooms = new Room[] {
                new Room { HotelId=1, Capacity=2, Description="Very cool exotic room", Type="Standard Double"},
                new Room { HotelId=1, Capacity=1, Description="Very cool exotic room", Type="Standard Single"},
                new Room { HotelId=2, Capacity=2, Description="Very nice exotic room", Type="Standard Double"},
                new Room { HotelId=2, Capacity=1, Description="Very nice exotic room", Type="Standard Single"}
            };
             foreach(Room r in rooms) {
                context.Add(r);
            }
            context.SaveChanges();

            var bookings = new Booking[] {
                new Booking{ UserId=1,RoomId=1,From=DateTime.Parse("2021-03-11"),To=DateTime.Parse("2021-01-22"),Active=true},
                new Booking{ UserId=2,RoomId=2,From=DateTime.Parse("2021-04-11"),To=DateTime.Parse("2021-03-22"),Active=true}
            };
            foreach(Booking b in bookings) {
                context.Add(b);
            }
            context.SaveChanges();

            var roomAmenities = new RoomAmenity[] {
                new RoomAmenity { RoomId=1, Balcony=true, WaterHeater=true, Internet=true, WorkSpace=true},
                new RoomAmenity { RoomId=2, Balcony=true, WaterHeater=true, Internet=true, WorkSpace=true},
                new RoomAmenity { RoomId=3, Balcony=true, WaterHeater=true, Internet=true, WorkSpace=true},
                new RoomAmenity { RoomId=4, Balcony=false, WaterHeater=true, Internet=true, WorkSpace=false}
            };
             foreach(RoomAmenity a in roomAmenities) {
                context.Add(a);
            }
            context.SaveChanges();

            var roomImages = new RoomImage[] {
                new RoomImage { RoomId=1,Url="www.pics.com/images/1"},
                new RoomImage { RoomId=2,Url="www.pics.com/images/2"},
                new RoomImage { RoomId=3,Url="www.pics.com/images/3"},
                new RoomImage { RoomId=4,Url="www.pics.com/images/4"}
            };
             foreach(RoomImage i in roomImages) {
                context.Add(i);
            }
            context.SaveChanges();
        }
    }
}