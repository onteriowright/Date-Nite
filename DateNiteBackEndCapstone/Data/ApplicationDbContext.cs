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
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<DateResults> DatesResults { get; set; }
        public DbSet<RestaurantResult> RestaurantResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Business>()
                .Property(r => r.Rating)
                .HasColumnType("decimal(18,4)");
        }
    }
}
