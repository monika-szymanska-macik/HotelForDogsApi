using Microsoft.EntityFrameworkCore;
using HotelForDogs.Entities;
using System;

namespace HotelForDogs.DbContexts
{
    public class DogHotelContext : DbContext 
    {
        public DogHotelContext(DbContextOptions<DogHotelContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog()
                {
                    DogId = 1,
                    Name = "Rex",
                    Breed = "Crossbreed",
                    Weight = 15,
                    ClientId = 1
                },
                new Dog()
                {
                    DogId = 2,
                    Name = "Max",
                    Breed = "Basset",
                    Weight = 8,
                    ClientId = 1
                },
                new Dog()
                {
                    DogId = 3,
                    Name = "Fred",
                    Breed = "Colli",
                    Weight = 36,
                    ClientId = 3
                }
                );
            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    ClientId = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PhoneNumber = "505505505",

                },
                new Client()
                {
                    ClientId = 2,
                    FirstName = "Jan",
                    LastName = "Nowak",
                    PhoneNumber = "606606606",
                },
                new Client()
                {
                    ClientId = 3,
                    FirstName = "John",
                    LastName = "Smith",
                    PhoneNumber = "707707707",
                }
                );
            modelBuilder.Entity<Reservation>().HasData(

                new Reservation()
                {
                    ReservationId = 1,
                    ClientId = 1,
                    DaysNumberOfStay = 7
                },
                new Reservation()
                {
                    ReservationId = 2,
                    ClientId = 1,
                    DaysNumberOfStay = 2
                }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
