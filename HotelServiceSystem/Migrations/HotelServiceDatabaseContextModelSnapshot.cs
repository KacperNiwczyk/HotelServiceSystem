﻿// <auto-generated />
using System;
using HotelServiceSystem.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelServiceSystem.Migrations
{
    [DbContext(typeof(HotelServiceDatabaseContext))]
    partial class HotelServiceDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HotelServiceSystem.Entities.AdditionalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.AdditionalServiceReservation", b =>
                {
                    b.Property<int>("AdditionalServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("AdditionalServiceId", "ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("AdditionalServiceReservation");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Bed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BedType")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfSubmission")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Reservation_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Reservation");

                    b.HasDiscriminator<string>("Reservation_Type").HasValue("Reservation");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOutOfService")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RoomIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ShouldBeCleaned")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.RoomReservation", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("RoomReservations");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.EventReservation", b =>
                {
                    b.HasBaseType("HotelServiceSystem.Entities.Reservation");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Event");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.HotelReservation", b =>
                {
                    b.HasBaseType("HotelServiceSystem.Entities.Reservation");

                    b.HasDiscriminator().HasValue("Hotel");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.AdditionalServiceReservation", b =>
                {
                    b.HasOne("HotelServiceSystem.Entities.AdditionalService", "AdditionalService")
                        .WithMany("AdditionalServiceReservations")
                        .HasForeignKey("AdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelServiceSystem.Entities.Reservation", "Reservation")
                        .WithMany("AdditionalServiceReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Bed", b =>
                {
                    b.HasOne("HotelServiceSystem.Entities.Room", "Room")
                        .WithMany("Beds")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Reservation", b =>
                {
                    b.HasOne("HotelServiceSystem.Entities.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.RoomReservation", b =>
                {
                    b.HasOne("HotelServiceSystem.Entities.HotelReservation", "HotelReservation")
                        .WithMany("RoomReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelServiceSystem.Entities.Room", "Room")
                        .WithMany("RoomReservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelReservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.AdditionalService", b =>
                {
                    b.Navigation("AdditionalServiceReservations");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Reservation", b =>
                {
                    b.Navigation("AdditionalServiceReservations");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.Room", b =>
                {
                    b.Navigation("Beds");

                    b.Navigation("RoomReservations");
                });

            modelBuilder.Entity("HotelServiceSystem.Entities.HotelReservation", b =>
                {
                    b.Navigation("RoomReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
