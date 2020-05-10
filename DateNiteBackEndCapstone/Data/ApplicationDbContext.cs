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
        public DbSet<DateBusiness> DateBusiness { get; set; }
        public DbSet<UserBusiness> UserBusinesses { get; set; }

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
        }
    }
}
