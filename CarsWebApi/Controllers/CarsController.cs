using System;
using System.Linq;
using CarsWebApi.BL;
using CarsWebApi.BL.Helpers;
using CarsWebApi.Database;
using CarsWebApi.Database.DTO;
using CarsWebApi.Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private readonly CarService _carService;
        private readonly UriService _uriService;

        public IQueryable<Car> TotalCars => _context.Cars;
        public string Route => Request.Path.Value;

        public CarsController(
            WebApiDbContext context,
            CarService carService,
            UriService uriService)
        {
            _context = context;
            _carService = carService;
            _uriService = uriService;
        }

        [HttpGet]
        public IActionResult GetCars([FromQuery] PaginationFilter filter)
        {
            return Ok(ResponseHelper.CreateResponse<Car>(_context, filter, _uriService, Route));
        }

        [HttpGet]
        [Route("{carId}/rents")]
        public IActionResult GetRentsByCarId(Guid carId, [FromQuery] PaginationFilter filter)
        {
            var response = _carService.GetRentsByCarId(carId, filter, _uriService, Route);
            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{carId}/users")]
        public IActionResult GetUsersByCarId(Guid carId, [FromQuery] PaginationFilter filter)
        {
            var response = _carService.GetUsersByCarId(carId, filter, _uriService, Route);
            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetCar([FromQuery] CarDto? request, [FromQuery] PaginationFilter filter)
        {
            if (request != null)
            {
                var response = _carService.GetCarsByFilter(request, filter, _uriService, Route);
                if (response == null)
                {
                    return NoContent();
                }

                return Ok(response);
            }
            else
            {
                return Ok(ResponseHelper.CreateResponse<Car>(_context, filter, _uriService, Route));
            }
        }

        [HttpGet]
        [Route("range")]
        public IActionResult GetAvailableCars([FromQuery]DateRange range, [FromQuery] PaginationFilter filter)
        {
            var response = _carService.GetCarsByRange(range, filter, _uriService, Route);
            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddCar([Bind("Id,Brand,Model,Price,Transmission,TypeEngine,Engine,Passengers")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.Id = Guid.NewGuid();
                _context.Add(car);
                _context.SaveChanges();
                return Ok(car);
            }

            return BadRequest("Model is invalid");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCarById(Guid? id)
        {
            if (id == null) return BadRequest("Id should not be null");

            var car = _context.Cars.First(c => c.Id == id);

            if (car == null) return NotFound("Car with specified Id was not found");

            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCar(Guid id,
            [Bind("Id,Brand,Model,Price,Transmission,TypeEngine,Engine,Passengers")]
            Car car)
        {
            if (id != car.Id)
            {
                return BadRequest("Provided Id does not correspond to updated car Id");
            }

            if (ModelState.IsValid)
            {
                if (_context.Cars.Count(c => c.Id == id) == 0)
                {
                    return NotFound("Car with specified Id was not found");
                }

                try
                {
                    _context.Cars.Update(car);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Conflict("Database conflict occurred during updating the car");
                }

                return Ok();
            }

            return BadRequest("Model validation failed");
        }
    }
}
