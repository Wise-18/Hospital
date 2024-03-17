using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Hospital.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HospitalWard>();

            modelBuilder.Entity<Patient>()
                .OwnsOne<Person>(t => t.PersonalData);
        }
    }
}
