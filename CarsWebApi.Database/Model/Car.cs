using System;
using System.ComponentModel.DataAnnotations;

namespace CarsWebApi.Database.Model
{
    public class Car
    {
        public Guid Id { get; set; }

        [Required]
        [Range(0, 12, ErrorMessage = "Incorrect Brand type")]
        public Brands Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Range(0, 2, ErrorMessage = "Incorrect Transmission type")]
        public Transmissions Transmission { get; set; }

        [Required]
        [Range(0, 3, ErrorMessage = "Incorrect TypeEngine type")]
        public TypeEngines TypeEngine { get; set; }

        [Required]
        [Range(0.1, 15.0, ErrorMessage = "Engine volume is out of range")]
        public double Engine { get; set; }

        [Required]
        [Range(1, 35, ErrorMessage = "Passengers number is of range")]
        public int Passengers { get; set; }
    }
}
