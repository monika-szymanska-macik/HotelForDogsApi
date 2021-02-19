using Microsoft.EntityFrameworkCore;
using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.DbContext
{
    public class HotelForDogsContext : DbContext
    {
        public HotelForDogsContext(DbContextOptions<HotelForDogsContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
            )
        }

    }
}
