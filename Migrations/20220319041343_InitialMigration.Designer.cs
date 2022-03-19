﻿// <auto-generated />
using System;
using DataAnnotations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAnnotations.Migrations
{
    [DbContext(typeof(DataAnnotationsContext))]
    [Migration("20220319041343_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAnnotations.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("DataAnnotations.Models.Credit", b =>
                {
                    b.Property<int>("CreditNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditNumber"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.HasKey("CreditNumber");

                    b.HasIndex("ClientId");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("DataAnnotations.Models.CurrentBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurrentClientId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentRoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentClientId");

                    b.HasIndex("CurrentRoomNumber");

                    b.ToTable("CurrentBooking");
                });

            modelBuilder.Entity("DataAnnotations.Models.PreviousBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PreviousClientId")
                        .HasColumnType("int");

                    b.Property<int>("PreviousRoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreviousClientId");

                    b.HasIndex("PreviousRoomNumber");

                    b.ToTable("PreviousBooking");
                });

            modelBuilder.Entity("DataAnnotations.Models.Room", b =>
                {
                    b.Property<int>("RoomNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomNumber"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("RoomNumber");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("DataAnnotations.Models.Credit", b =>
                {
                    b.HasOne("DataAnnotations.Models.Client", "Client")
                        .WithMany("Credits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DataAnnotations.Models.CurrentBooking", b =>
                {
                    b.HasOne("DataAnnotations.Models.Client", "CurrentClient")
                        .WithMany("CurrentBookings")
                        .HasForeignKey("CurrentClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAnnotations.Models.Room", "CurrentRoom")
                        .WithMany("CurrentBookings")
                        .HasForeignKey("CurrentRoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentClient");

                    b.Navigation("CurrentRoom");
                });

            modelBuilder.Entity("DataAnnotations.Models.PreviousBooking", b =>
                {
                    b.HasOne("DataAnnotations.Models.Client", "PreviousClient")
                        .WithMany("PreviousBookings")
                        .HasForeignKey("PreviousClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAnnotations.Models.Room", "PreviousRoom")
                        .WithMany("PreviousBookings")
                        .HasForeignKey("PreviousRoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreviousClient");

                    b.Navigation("PreviousRoom");
                });

            modelBuilder.Entity("DataAnnotations.Models.Client", b =>
                {
                    b.Navigation("Credits");

                    b.Navigation("CurrentBookings");

                    b.Navigation("PreviousBookings");
                });

            modelBuilder.Entity("DataAnnotations.Models.Room", b =>
                {
                    b.Navigation("CurrentBookings");

                    b.Navigation("PreviousBookings");
                });
#pragma warning restore 612, 618
        }
    }
}