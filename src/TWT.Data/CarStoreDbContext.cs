using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Data
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
