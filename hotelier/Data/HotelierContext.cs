
using hotelier.Models;
using Microsoft.EntityFrameworkCore;

namespace hotelier.Data {

    public class HotelierContext : DbContext {

        public HotelierContext(DbContextOptions<HotelierContext> options) : base(options) {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<User> Users { get; set; }
  
         
    }
}