using System;
using System.Collections.Generic;
using System.Linq;
using CarsWebApi.Bl.Helpers;
using CarsWebApi.BL.Helpers;
using CarsWebApi.Database;
using CarsWebApi.Database.Model;

namespace CarsWebApi.BL
{
    public class UserService
    {
        private readonly WebApiDbContext _context;

        public UserService(WebApiDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsersByCarId(Guid carId, PaginationFilter filter)
        {
            var users = _context.Rents
                .Where(r => r.CarId == carId)
                .Select(u => u.UserId);
            return _context.Users
                .Where(u => users.Contains(u.Id))
                .OrderBy(u => u.LastName);
        }

        public bool UserExist(Guid userId)
        {
            return _context.Users.Count(u => u.Id == userId) == 1;
        }

        public Response<List<Rent>> GetRentsByUserId(Guid userId, PaginationFilter filter, UriService uriService, string route)
        {
            if (!UserExist(userId))
            {
                return null;
            }

            var rents =  _context.Rents
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.DateTo).ToList();
            return ResponseHelper.CreateResponse(_context, filter, uriService, route, rents);
        }

        public Response<List<User>> GetUserById(Guid userId, UriService uriService, string route)
        {
            if (!UserExist(userId))
            {
                return null;
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            return ResponseHelper.CreateResponse(_context, new PaginationFilter(), uriService, route, new List<User> {user});
        }
    }
}
