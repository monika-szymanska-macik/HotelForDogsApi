using Microsoft.EntityFrameworkCore;
using HotelForDogs.Entities;
using System;

namespace HotelForDogs.DbContexts
{
    public class ClientContext : DbContext 
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog()
                {
                    DogId = 1,
                    Name = "Rex",
                    Breed = "Crossbreed",
                    Weight = 15
                },
                new Dog()
                {
                    DogId = 2,
                    Name = "Max",
                    Breed = "Basset",
                    Weight = 8
                },
                new Dog()
                {
                    DogId = 3,
                    Name = "Fred",
                    Breed = "Colli",
                    Weight = 36
                }
                );
            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    ClientId = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PhoneNumber = "505505505",
                    DogId = 1

                },
                new Client()
                {
                    ClientId = 2,
                    FirstName = "Jan",
                    LastName = "Nowak",
                    PhoneNumber = "606606606",
                    DogId = 2
                },
                new Client()
                {
                    ClientId = 3,
                    FirstName = "John",
                    LastName = "Smith",
                    PhoneNumber = "707707707",
                    DogId = 3
                }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
