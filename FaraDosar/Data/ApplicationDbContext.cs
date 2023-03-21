using FaraDosar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FaraDosar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Card> Cards { get; set; }
        /*public DbSet<Profile> Profiles { get; set; }*/

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Hour> Hours { get; set; }


        public DbSet<Location> Locations { get; set; }
    }
}