using HotelServiceSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core
{
    public class HotelServiceDatabaseContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=HSSDatabase;User Id=sa;Password=admin";
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<HotelReservation> HotelReservations { get; set; }
        public DbSet<EventReservation> EventReservations { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<AdditionalServiceReservation> AdditionalServiceReservations { get; set; }
        public DbSet<AdditionalServiceRoom> AdditionalServiceRooms { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }

        public HotelServiceDatabaseContext(DbContextOptions<HotelServiceDatabaseContext> options) : base (options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Client -> Reservation
            modelBuilder.Entity<Client>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Client);

            //Room -> Bed
            modelBuilder.Entity<Room>()
                .HasMany(x => x.Beds)
                .WithOne(x => x.Room);

            //Room -> Reservation, Reservation -> Room
            modelBuilder.Entity<RoomReservation>()
                .HasKey(x => new {x.RoomId, x.ReservationId});
            modelBuilder.Entity<RoomReservation>()
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomReservations)
                .HasForeignKey(x => x.RoomId);
            modelBuilder.Entity<RoomReservation>()
                .HasOne(x => x.Reservation)
                .WithMany(x => x.RoomReservations)
                .HasForeignKey(x => x.ReservationId);
            modelBuilder.Entity<Reservation>()
                .HasDiscriminator<string>("Reservation_Type")
                .HasValue<HotelReservation>("Hotel")
                .HasValue<EventReservation>("Event");
            modelBuilder.Entity<AdditionalServiceReservation>()
                .HasKey(x => new {x.AdditionalServiceId, x.ReservationId});
            modelBuilder.Entity<AdditionalServiceReservation>()
                .HasOne(x => x.AdditionalService)
                .WithMany(x => x.AdditionalServiceReservations)
                .HasForeignKey(x => x.AdditionalServiceId);
            modelBuilder.Entity<AdditionalServiceReservation>()
                .HasOne(x => x.Reservation)
                .WithMany(x => x.AdditionalServiceReservations)
                .HasForeignKey(x => x.ReservationId);
            modelBuilder.Entity<AdditionalServiceRoom>()
                .HasKey(x => new {x.AdditionalServiceId, x.RoomId});
            modelBuilder.Entity<AdditionalServiceRoom>()
                .HasOne(x => x.AdditionalService)
                .WithMany(x => x.AdditionalServiceRooms)
                .HasForeignKey(x => x.AdditionalServiceId);
            modelBuilder.Entity<AdditionalServiceRoom>()
                .HasOne(x => x.Room)
                .WithMany(x => x.AdditionalServiceRooms)
                .HasForeignKey(x => x.RoomId);
        }
    }
}