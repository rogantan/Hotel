using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Models.Data
{
    public class MyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=hotel;Username=postgres;Password=yfhmzy03");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckInService>()
                .HasNoKey(); // Укажите, что это сущность без ключа
            modelBuilder.Entity<ReservationClient>().HasNoKey();
            modelBuilder.Entity<Departure>().HasNoKey();
        }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<CheckIn> CheckIns { get; set; } = null!;
        public DbSet<Departure> Departures { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null !;
        public DbSet<Discount> Discounts { get; set; } = null!;
        public DbSet<CheckInService> CheckInsServices { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<ReservationClient> ReservationsClients { get; set; } = null!;

        private static MyDatabase? instance;
        public static MyDatabase getInstance()
        {
            if (instance == null)
            {
                instance = new MyDatabase();
                //instance.Database.EnsureDeleted();
                //var exists = instance.Database.EnsureCreated();

                instance.Clients.Load();
                instance.Reservations.Load();
                instance.CheckIns.Load();
                instance.Departures.Load();
                instance.Rooms.Load();
                instance.Discounts.Load();
                instance.Employees.Load();
                instance.CheckInsServices.Load();
                instance.Services.Load();
                instance.ReservationsClients.Load();

                instance.SaveChanges();
            }
            return instance;
        }
    }
}
