#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using CarsWebApi.Bl.Helpers;
using CarsWebApi.BL.Helpers;
using CarsWebApi.Database;
using CarsWebApi.Database.DTO;
using CarsWebApi.Database.Model;

namespace CarsWebApi.BL
{
    public class CarService
    {
        private readonly WebApiDbContext _context;

        private IQueryable<Car> _cars;

        public CarService(WebApiDbContext context)
        {
            _context = context;
        }

        public bool CarExist(Guid carId)
        {
            return _context.Cars.Count(c => c.Id == carId) == 1;
        }

        public IQueryable<Car> FilterCars(CarDto? request, PaginationFilter filter)
        {
            _cars = _context.Cars;
            if (request != null)
            {
                this.GetById(request);
                this.GetByBrand(request);
                this.GetByModel(request);
                this.GetByPrice(request);
                this.GetByTransmission(request);
                this.GetByTypeEngine(request);
                this.GetByEngine(request);
                this.GetByPassengersNumber(request);
            }

            return _cars;
        }

        private void GetById(CarDto request)
        {
            if (request.CarId != null)
            {
                _cars = _cars.Where(c => c.Id == request.CarId);
            }
        }

        private void GetByBrand(CarDto request)
        {
            if (request.Brand != null)
            {
                _cars = _cars.Where(c => c.Brand == request.Brand);
            }
        }

        private void GetByModel(CarDto request)
        {
            if (request.Model !=string.Empty)
            {
                _cars = _cars.Where(c => c.Model == request.Model);
            }
        }

        private void GetByPrice(CarDto request)
        {
            if (request.PriceMinValue != 0 || request.PriceMaxValue < double.MaxValue)
            {
                _cars = _cars.Where(c => c.Price >= request.PriceMinValue && c.Price <= request.PriceMaxValue);
            }
        }

        private void GetByTransmission(CarDto request)
        {
            if (request.Transmission != null)
            {
                _cars = _cars.Where(c => c.Transmission == request.Transmission);
            }
        }

        private void GetByTypeEngine(CarDto request)
        {
            if (request.TypeEngine != null)
            {
                _cars = _cars.Where(c => c.TypeEngine == request.TypeEngine);
            }
        }

        private void GetByEngine(CarDto request)
        {
            if (request.EngineMin > 0.1 || request.EngineMax < 15.0)
            {
                _cars = _cars.Where(c => c.Engine >= request.EngineMin && c.Engine <= request.EngineMax);
            }
        }

        private void GetByPassengersNumber(CarDto request)
        {
            if (request.PassengersMin > 1 || request.PassengersMax < 35)
            {
                _cars = _cars.Where(c =>
                    c.Passengers >= request.PassengersMin && c.Passengers <= request.PassengersMax);
            }
        }

        public Response<List<Rent>>? GetRentsByCarId(Guid carId, PaginationFilter filter, UriService uriService, string route)
        {
            if (!CarExist(carId))
            {
                return null;
            }

            List<Rent>? rents = _context.Rents
                .Where(r => r.CarId == carId)
                .OrderByDescending(r => r.DateTo).ToList();
            return ResponseHelper.CreateResponse(_context, filter, uriService, route, rents);
        }

        public Response<List<User>>? GetUsersByCarId(Guid carId, PaginationFilter filter, UriService uriService, string route)
        {
            if (!CarExist(carId))
            {
                return null;
            }

            var rents = _context.Rents.Where(r => r.CarId == carId).Select(r => r.UserId);
            var users = _context.Users
                .Where(u => rents.Contains(u.Id)).ToList();
            return ResponseHelper.CreateResponse<User>(_context, filter, uriService, route, users);
        }

        public Response<List<Car>>? GetCarsByFilter(CarDto request, PaginationFilter filter, UriService uriService, string route)
        {
            var cars = FilterCars(request, filter).ToList();
            if (!cars.Any())
            {
                return null;
            }
            return ResponseHelper.CreateResponse(_context, filter, uriService, route, cars);
        }

        public Response<List<Car>>? GetCarsByRange(DateRange range, PaginationFilter filter, UriService uriService, string route)
        {

            List<Car> availableCars = new List<Car>();
            foreach (var car in _context.Cars)
            {
                if (!IsCarBooked(car.Id, range.DateFrom, range.DateTo))
                {
                    availableCars.Add(car);
                }
            }

            if (availableCars.Count == 0)
            {
                return null;
            }

            return ResponseHelper.CreateResponse(_context, filter, uriService, route, availableCars);
        }

        public bool IsCarBooked(Guid rentCarId, DateTime rentDateFrom, DateTime rentDateTo)
        {
            return _context.Rents
                .Where(r => r.CarId == rentCarId)
                .Any(r =>
                    (rentDateFrom >= r.DateFrom && rentDateFrom < r.DateTo)
                    || (rentDateTo > r.DateFrom && rentDateTo <= r.DateTo));
        }
    }
}
