using System;
using System.Collections.Generic;
using System.Linq;
using CarsWebApi.Bl.Helpers;
using CarsWebApi.Bl.Interfaces;
using CarsWebApi.Database;
using CarsWebApi.Database.Model;

namespace CarsWebApi.BL.Helpers
{
    public class ResponseHelper
    {
        private static int _totalEntities;

        public static Response<List<T>> CreateResponse<T>(WebApiDbContext context, PaginationFilter filter, IUriService uriService, string route, List<T>? data = null)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (uriService is null)
            {
                throw new ArgumentNullException(nameof(uriService));
            }

            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentException($"'{nameof(route)}' cannot be null or empty.", nameof(route));
            }

            data = data == null ? ApplyPagination<T>(context, filter, null).ToList() : ApplyPagination<T>(context, filter, data).ToList();

            var response = new Response<List<T>>(data.ToList(), filter.PageNumber, filter.PageSize);
            var totalPages = (_totalEntities / (double)filter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.NextPage =
                filter.PageNumber >= 1 && filter.PageNumber < roundedTotalPages
                    ? uriService.GetPageUri(new PaginationFilter(filter.PageNumber + 1, filter.PageSize), route)
                    : null;
            response.PreviousPage =
                filter.PageNumber - 1 >= 1 && filter.PageNumber <= roundedTotalPages
                    ? uriService.GetPageUri(new PaginationFilter(filter.PageNumber - 1, filter.PageSize), route)
                    : null;
            response.FirstPage = uriService.GetPageUri(new PaginationFilter(1, filter.PageSize), route);
            response.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, filter.PageSize), route);
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = _totalEntities;
            return response;
        }

        private static IEnumerable<T> ApplyPagination<T>(WebApiDbContext context, PaginationFilter filter, List<T>? data)
        {

            if (data != null)
            {
                _totalEntities = data.Count;
                return data.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);
            }

            switch (typeof(T).Name)
            {
                case nameof(Car):
                    _totalEntities = context.Cars.Count();
                    return context
                        .Cars
                        .OrderBy(c => c.Price)
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize) as IEnumerable<T>;
                case nameof(Rent):
                    _totalEntities = context.Rents.Count();
                    return context
                        .Rents
                        .OrderBy(r => r.CarId)
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize) as IEnumerable<T>;
                case nameof(User):
                    _totalEntities = context.Users.Count();
                    return context
                        .Users
                        .OrderBy(u => u.LastName)
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize) as IEnumerable<T>;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
