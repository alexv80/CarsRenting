using System.Linq;
using RentCar.Core.Models;

namespace RentCar.Core.Abstraction
{
    public interface ICarRepository
    {
        IQueryable<Car> Cars { get; }
    }
}
