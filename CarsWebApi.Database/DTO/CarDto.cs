using System;
using System.ComponentModel.DataAnnotations;
using CarsWebApi.Database.Model;

namespace CarsWebApi.Database.DTO
{
    public class CarDto
    {
        public Guid? CarId { get; set; }

        [Range(0,12, ErrorMessage = "Incorrect Brand type")]
        public Brands? Brand { get; set; }

        public string Model { get; set; } = string.Empty;

        public double PriceMinValue { get; set; } = 0.0;

        public double PriceMaxValue { get; set; } = double.MaxValue;

        [Range(0, 2, ErrorMessage = "Incorrect Transmission type")]
        public Transmissions? Transmission { get; set; }

        [Range(0,3, ErrorMessage = "Incorrect TypeEngine type")]
        public TypeEngines? TypeEngine { get; set; }

        [Range(0.1, 15.0, ErrorMessage = "Engine volume is out of range")]
        public double? EngineMin { get; set; } = 0.1;

        [Range(0.1, 15.0, ErrorMessage = "Engine volume is out of range")]
        public double? EngineMax { get; set; } = 15.0;

        public int PassengersMin { get; set; } = 1;

        public int PassengersMax { get; set; } = 35;
    }
}
