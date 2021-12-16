using System;
using System.ComponentModel.DataAnnotations;

namespace CarsWebApi.Database.Model
{
    public  class Rent
    {
        public Guid Id { get; set; }

        [Required]
        public Guid CarId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }
    }
}
