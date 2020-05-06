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
        public DbSet<RestaurantResult> RestaurantResults { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventResult> EventResults { get; set; }
    }
}
