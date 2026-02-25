using Microsoft.EntityFrameworkCore;
using VilaBookingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilaBookingService.Infrastructure.Data
{
    public class VilaBookingContext(DbContextOptions<VilaBookingContext> options) : DbContext(options)
    {
        public DbSet<Vila> Vilas { get; set; }
        public DbSet<VilaNumber> VilaNumbers { get; set; }
        public DbSet<Amenity> Amenities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Vila>().HasData(
                new Vila
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://placehold.co/600x400",
                    Occupancy = 4,
                    Price = 200,
                    Sqft = 550,
                },
                    new Vila
                    {
                        Id = 2,
                        Name = "Premium Pool Villa",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        ImageUrl = "https://placehold.co/600x401",
                        Occupancy = 4,
                        Price = 300,
                        Sqft = 550,
                    },
                    new Vila
                    {
                        Id = 3,
                        Name = "Luxury Pool Villa",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        ImageUrl = "https://placehold.co/600x402",
                        Occupancy = 4,
                        Price = 400,
                        Sqft = 750,
                    });

            modelBuilder.Entity<VilaNumber>().HasData(
                new VilaNumber
                {
                    Vila_Number = 101,
                    VilaId = 1
                },
                new VilaNumber
                {
                    Vila_Number = 102,
                    VilaId = 1
                },
                new VilaNumber
                {
                    Vila_Number = 103,
                    VilaId = 1
                },
                new VilaNumber
                {
                    Vila_Number = 104,
                    VilaId = 1
                },
                new VilaNumber
                {
                    Vila_Number = 201,
                    VilaId = 2,
                },
                new VilaNumber
                {
                    Vila_Number = 202,
                    VilaId = 2
                },
                new VilaNumber
                {
                    Vila_Number = 203,
                    VilaId = 2
                },
                new VilaNumber
                {
                    Vila_Number = 204,
                    VilaId = 2
                },
                new VilaNumber
                {
                    Vila_Number = 302,
                    VilaId = 3
                },
                new VilaNumber
                {
                    Vila_Number = 303,
                    VilaId = 3
                }
                );
            */
            modelBuilder.Entity<Amenity>().HasData(
          new Amenity
          {
              Id = 1,
              VilaId = 45,
              Name = "Private Pool"
          }, new Amenity
          {
              Id = 2,
              VilaId = 45,
              Name = "Microwave"
          }, new Amenity
          {
              Id = 3,
              VilaId = 45,
              Name = "Private Balcony"
          }, new Amenity
          {
              Id = 4,
              VilaId = 45,
              Name = "1 king bed and 1 sofa bed"
          },

          new Amenity
          {
              Id = 5,
              VilaId = 46,
              Name = "Private Plunge Pool"
          }, new Amenity
          {
              Id = 6,
              VilaId = 46,
              Name = "Microwave and Mini Refrigerator"
          }, new Amenity
          {
              Id = 7,
              VilaId = 46,
              Name = "Private Balcony"
          }, new Amenity
          {
              Id = 8,
              VilaId = 46,
              Name = "king bed or 2 double beds"
          },

          new Amenity
          {
              Id = 9,
              VilaId = 47,
              Name = "Private Pool"
          }, new Amenity
          {
              Id = 10,
              VilaId = 47,
              Name = "Jacuzzi"
          }, new Amenity
          {
              Id = 11,
              VilaId = 47,
              Name = "Private Balcony"
          });
        }
    }
}
