using System;
using System.Linq;
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
    public class UsersController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private readonly UserService _userService;
        private readonly UriService _uriService;

        public string Route => Request.Path.Value;

        public UsersController(
            WebApiDbContext context,
            UserService userService,
            UriService uriService)
        {
            _context = context;
            _userService = userService;
            _uriService = uriService;
        }

        [HttpGet]
        public IActionResult AllUsers([FromQuery] PaginationFilter filter)
        {
            return Ok(ResponseHelper.CreateResponse<User>(_context, filter, _uriService, Route));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById(Guid? id)
        {
            if (id == null)
            {
                return NoContent();
            }

            var response = _userService.GetUserById(id.Value, _uriService, Route);

            if (response == null)
            {
                return NotFound("User with specified Id was not found");
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{userId}/rents")]
        public IActionResult GetRentsByUserId(Guid userId, [FromQuery] PaginationFilter filter)
        {
            var response = _userService.GetRentsByUserId(userId, filter, _uriService, Route);
            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddUser([Bind("Id,FirstName,LastName")] User user)
        {
            if (_userService.UserExist(user.Id))
            {
                return BadRequest("User with specified Id already exists");
            }

            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                _context.Add(user);
                _context.SaveChanges();
                return Ok(_context.Users);
            }

            return BadRequest("Model is not valid");
        }

        [HttpPut]
        public IActionResult UpdateUser(Guid id, [Bind("Id,FirstName,LastName")] User user)
        {
            if (id != user.Id)
            {
                return NotFound("Provided Id does not correspond to updated user Id");
            }

            if (!_userService.UserExist(user.Id))
            {
                return NotFound("User with specified Id was not found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Conflict("Database conflict has occurred during user update operation");
                }
                return Ok(_context.Users);
            }
            return BadRequest("Model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("Id should not be null");
            }

            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound("User with specified Id was not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
