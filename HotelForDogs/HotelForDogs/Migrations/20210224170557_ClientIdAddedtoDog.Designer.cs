﻿// <auto-generated />
using HotelForDogs.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelForDogs.Migrations
{
    [DbContext(typeof(DogHotelContext))]
    [Migration("20210224170557_ClientIdAddedtoDog")]
    partial class ClientIdAddedtoDog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelForDogs.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            PhoneNumber = "505505505"
                        },
                        new
                        {
                            ClientId = 2,
                            FirstName = "Jan",
                            LastName = "Nowak",
                            PhoneNumber = "606606606"
                        },
                        new
                        {
                            ClientId = 3,
                            FirstName = "John",
                            LastName = "Smith",
                            PhoneNumber = "707707707"
                        });
                });

            modelBuilder.Entity("HotelForDogs.Entities.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("DogId");

                    b.HasIndex("ClientId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            DogId = 1,
                            Breed = "Crossbreed",
                            ClientId = 1,
                            Name = "Rex",
                            Weight = 15
                        },
                        new
                        {
                            DogId = 2,
                            Breed = "Basset",
                            ClientId = 1,
                            Name = "Max",
                            Weight = 8
                        },
                        new
                        {
                            DogId = 3,
                            Breed = "Colli",
                            ClientId = 3,
                            Name = "Fred",
                            Weight = 36
                        });
                });

            modelBuilder.Entity("HotelForDogs.Entities.Dog", b =>
                {
                    b.HasOne("HotelForDogs.Entities.Client", "Client")
                        .WithMany("Dogs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HotelForDogs.Entities.Client", b =>
                {
                    b.Navigation("Dogs");
                });
#pragma warning restore 612, 618
        }
    }
}
