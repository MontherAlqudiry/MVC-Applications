﻿// <auto-generated />
using Demo_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo_API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "New york city",
                            Age = 25,
                            ImageUrl = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                            Name = "Jack"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Las Vegas",
                            Age = 22,
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fperson&psig=AOvVaw3zCQm5ilRKKKhIZfbIhuIt&ust=1697005510532000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPiBkafs6oEDFQAAAAAdAAAAABAE",
                            Name = "Rose"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Madried",
                            Age = 28,
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fprofile-image&psig=AOvVaw3zCQm5ilRKKKhIZfbIhuIt&ust=1697005510532000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPiBkafs6oEDFQAAAAAdAAAAABAJ",
                            Name = "Ron"
                        },
                        new
                        {
                            Id = 4,
                            Address = "sydney",
                            Age = 23,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRKouGaC5wkHjgKIuSSZTrTBBQWc5gEIOPFw&usqp=CAU",
                            Name = "Batrisha"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
