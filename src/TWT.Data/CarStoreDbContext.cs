using Microsoft.EntityFrameworkCore;
using TWT.Data.Models;
using TWT.Data.Seeds;

namespace TWT.Data
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CarSeed());
        }
        DbSet<Car> Cars { get; set; }
    }
}
