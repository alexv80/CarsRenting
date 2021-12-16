using System;
using CarsWebApi.BL;

namespace CarsWebApi.Bl.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}