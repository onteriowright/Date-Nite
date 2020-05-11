using System;
using System.Collections.Generic;
using System.Text;
using DateNiteBackEndCapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DateNiteBackEndCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<State> States { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Business>()
                .Property(r => r.Rating)
                .HasColumnType("decimal(18,4)");


            modelBuilder.Entity<LocationType>().HasData(
                new LocationType()
                {
                    LocationTypeId = 1,
                    Type = "Food"
                },
                new LocationType()
                {
                    LocationTypeId = 2,
                    Type = "Fun"
                }
            );

            modelBuilder.Entity<State>().HasData(
                new State()
                {
                    Id = 1,
                    Name = "AL"
                }, new State()
                {
                    Id = 2,
                    Name = "AK"
                }, new State()
                {
                    Id = 3,
                    Name = "AZ"
                }, new State()
                {
                    Id = 4,
                    Name = "AR"
                }, new State()
                {
                    Id = 5,
                    Name = "CA"
                }, new State()
                {
                    Id = 6,
                    Name = "CO"
                }, new State()
                {
                    Id = 7,
                    Name = "CT"
                }, new State()
                {
                    Id = 8,
                    Name = "DE"
                }, new State()
                {
                    Id = 9,
                    Name = "Fl"
                }, new State()
                {
                    Id = 10,
                    Name = "GA"
                }, new State()
                {
                    Id = 11,
                    Name = "HI"
                }, new State()
                {
                    Id = 12,
                    Name = "ID"
                }, new State()
                {
                    Id = 13,
                    Name = "IL"
                }, new State()
                {
                    Id = 14,
                    Name = "IN"
                }, new State()
                {
                    Id = 15,
                    Name = "IA"
                }, new State()
                {
                    Id = 16,
                    Name = "KS"
                }, new State()
                {
                    Id = 17,
                    Name = "KY"
                }, new State()
                {
                    Id = 18,
                    Name = "LA"
                }, new State()
                {
                    Id = 19,
                    Name = "ME"
                }, new State()
                {
                    Id = 20,
                    Name = "MD"
                }, new State()
                {
                    Id = 21,
                    Name = "MA"
                }, new State()
                {
                    Id = 22,
                    Name = "MI"
                }, new State()
                {
                    Id = 23,
                    Name = "MN"
                }, new State()
                {
                    Id = 24,
                    Name = "MS"
                }, new State()
                {
                    Id = 25,
                    Name = "MO"
                }, new State()
                {
                    Id = 26,
                    Name = "MT"
                }, new State()
                {
                    Id = 27,
                    Name = "NE"
                }, new State()
                {
                    Id = 28,
                    Name = "NV"
                }, new State()
                {
                    Id = 29,
                    Name = "NH"
                }, new State()
                {
                    Id = 30,
                    Name = "NJ"
                }, new State()
                {
                    Id = 31,
                    Name = "NM"
                }, new State()
                {
                    Id = 32,
                    Name = "NY"
                }, new State()
                {
                    Id = 33,
                    Name = "NC"
                }, new State()
                {
                    Id = 34,
                    Name = "ND"
                }, new State()
                {
                    Id = 35,
                    Name = "OH"
                }, new State()
                {
                    Id = 36,
                    Name = "OK"
                }, new State()
                {
                    Id = 37,
                    Name = "OR"
                }, new State()
                {
                    Id = 38,
                    Name = "PA"
                }, new State()
                {
                    Id = 39,
                    Name = "RI"
                }, new State()
                {
                    Id = 40,
                    Name = "SC"
                }, new State()
                {
                    Id = 41,
                    Name = "SD"
                }, new State()
                {
                    Id = 42,
                    Name = "TN"
                }, new State()
                {
                    Id = 43,
                    Name = "TX"
                }, new State()
                {
                    Id = 44,
                    Name = "UT"
                }, new State()
                {
                    Id = 45,
                    Name = "VT"
                }, new State()
                {
                    Id = 46,
                    Name = "VA"
                }, new State()
                {
                    Id = 47,
                    Name = "WA"
                }, new State()
                {
                    Id = 48,
                    Name = "WV"
                }, new State()
                {
                    Id = 49,
                    Name = "WI"
                }, new State()
                {
                    Id = 50,
                    Name = "WY"
                }

                );
        }
    }
}
