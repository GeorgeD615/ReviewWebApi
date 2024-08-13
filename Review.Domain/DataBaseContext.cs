using Microsoft.EntityFrameworkCore;
using Review.Domain.Helper;
using Review.Domain.Models;

namespace Review.Domain
{
    public class DataBaseContext: DbContext
    {
        public DbSet<Models.Review> Reviews { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var login = Initialization.SetLogins();
            modelBuilder.Entity<Login>().HasData(login);
        }
    }
}
