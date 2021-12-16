using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentCar.Core.Abstraction;
using RentCar.Core.Models;

namespace RentCar.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;

        private readonly ICarRepository _repository;

        public int PageSize = 3;

        public CarController(ICarRepository repository, ILogger<CarController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult List(int carPage = 1)
        {
            return View(
                new CarsCollection()
                {
                    Cars = _repository.Cars
                        .OrderBy(c => c.Price)
                        .Skip((carPage - 1) * PageSize)
                        .Take(PageSize)
                });
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
