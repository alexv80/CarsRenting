using System;
using CarsWebApi.BL;
using CarsWebApi.BL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsWebApi.Database;
using CarsWebApi.Database.Model;

namespace CarsWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private readonly RentService _rentService;
        private readonly CarService _carService;
        private readonly UriService _uriService;
        private readonly UserService _userService;

        public string Route => Request.Path.Value;

        public RentsController(WebApiDbContext context, RentService rentService, CarService carService, UriService uriService, UserService userService)
        {
            _context = context;
            _rentService = rentService;
            _carService = carService;
            _uriService = uriService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetRents([FromQuery] PaginationFilter filter)
        {
            return Ok(ResponseHelper.CreateResponse<Rent>(_context, filter, _uriService, Route));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRentById(Guid? id)
        {
            if (id == null)
            {
                return NoContent();
            }

            var response = _rentService.GetRentById(id.Value, _uriService, Route);

            if (response == null)
            {
                return NotFound("Rent with specified Id was not found");
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateRent([Bind("Id,DateFrom,DateTo")] Rent rent)
        {
            if (!_carService.CarExist(rent.CarId))
            {
                return BadRequest("Car with specified Id was not found");
            }

            if (!_userService.UserExist(rent.UserId))
            {
                return BadRequest("User with specified Id was not found");
            }

            if (ModelState.IsValid)
            {
                if (!_carService.IsCarBooked(rent.CarId, rent.DateFrom, rent.DateTo))
                {

                    rent.Id = Guid.NewGuid();
                    _context.Add(rent);
                    _context.SaveChanges();
                    return Ok(rent);
                }
                else
                {
                    return Conflict("Car is unavailable for selected range of dates");
                }
            }
            return BadRequest("Model is not valid");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditRent(Guid? id, [Bind("Id,DateFrom,DateTo")] Rent rent)
        {

            if (id == null)
            {
                return BadRequest("Id should not be null");
            }

            if (id != rent.Id)
            {
                return BadRequest("Id does not correspond to updated rent Id");
            }

            if (!_carService.CarExist((rent.CarId)))
            {
                return BadRequest("Car with specified Id was not found");
            }

            if (!_userService.UserExist((rent.UserId)))
            {
                return BadRequest("User with specified Id was not found");
            }

            if (!_rentService.RentExist(rent.Id))
            {
                return NotFound("Rent with specified Id was not found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Rents.Update(rent);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Conflict("Database conflict occurred during rent update operation");
                }
                return Ok(rent);
            }
            return BadRequest("Model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteConfirmed(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("Id should not be null");
            }

            var rent = _context.Rents.Find(id);

            if (rent == null)
            {
                return NotFound("Rent with specified Id was not found");
            }

            _context.Rents.Remove(rent);
            _context.SaveChanges();
            return Ok();
        }
    }
}
