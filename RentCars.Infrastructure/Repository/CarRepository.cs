using System.Linq;
using RentCar.Core.Abstraction;
using RentCar.Core.Models;

namespace RentCar.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private RentCarsDbContext context;

        public CarRepository(RentCarsDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Car> Cars => context.Cars;
    }
}
