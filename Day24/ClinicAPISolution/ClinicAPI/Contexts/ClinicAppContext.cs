using Microsoft.EntityFrameworkCore;
using ClinicAPI.Models;
namespace ClinicAPI.Contexts
{
    public class ClinicAppContext : DbContext
    {
        public ClinicAppContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Albatross", ExperienceInYears = 2, Specialization = "", ContactNumber = "1234567890", Email="alba@gmail.com"},
                new Doctor() { Id = 102, Name = "David Tim", ExperienceInYears = 3, Specialization = "", ContactNumber = "9876543211", Email = "tim@gmail.com" }
                );
        }
    }
}
