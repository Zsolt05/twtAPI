using Microsoft.EntityFrameworkCore;
using TWT.Data.Models;

namespace TWT.Data
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Car> Cars { get; set; }
    }
}
