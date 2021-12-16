using Microsoft.EntityFrameworkCore;
using RentCar.Core.Models;

namespace RentCar.Infrastructure.Repository
{
    public class RentCarsDbContext : DbContext
    {
        public RentCarsDbContext(DbContextOptions<RentCarsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
