﻿// <auto-generated />
using ClinicAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicAPI.Migrations
{
    [DbContext(typeof(ClinicAppContext))]
    partial class ClinicAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicAPI.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceInYears")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            ContactNumber = "1234567890",
                            Email = "alba@gmail.com",
                            ExperienceInYears = 2,
                            Name = "Albatross",
                            Specialization = "Neurologist"
                        },
                        new
                        {
                            Id = 102,
                            ContactNumber = "9876543211",
                            Email = "tim@gmail.com",
                            ExperienceInYears = 3,
                            Name = "David Tim",
                            Specialization = "Cardiologist"
                        },
                        new
                        {
                            Id = 103,
                            ContactNumber = "0000000000",
                            Email = "akatsuki@gmail.com",
                            ExperienceInYears = 15,
                            Name = "Akatsuki Rising",
                            Specialization = "Neurologist"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
