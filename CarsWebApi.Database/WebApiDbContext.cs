using CarsWebApi.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace CarsWebApi.Database
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rent> Rents { get; set; }
    }
}
