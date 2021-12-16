using System;
using System.Collections.Generic;
using System.Linq;
using CarsWebApi.BL.Helpers;
using CarsWebApi.Database;
using CarsWebApi.Database.Model;

namespace CarsWebApi.BL
{
    public class RentService
    {
        private readonly WebApiDbContext _context;

        public RentService(WebApiDbContext context)
        {
            _context = context;
        }

        public object GetRentById(Guid id, UriService uriService, string route)
        {
            if (!RentExist(id))
            {
                return null;
            }

            var rent = _context.Rents.FirstOrDefault(r => r.Id == id);

            return ResponseHelper.CreateResponse(_context, new PaginationFilter(), uriService, route, new List<Rent> { rent });
        }

        public bool RentExist(Guid rentId)
        {
            return _context.Rents.Count(r => r.Id == rentId) == 1;
        }
    }
}
