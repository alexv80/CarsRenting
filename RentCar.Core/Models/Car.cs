using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Core.Models
{
    public class Car
    {
        public Guid CarId { get; set; }

        public Brands Brand { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public Transmissions Transmission { get; set; }

        public TypeEngines TypeEngine { get; set; }

        public double Engine { get; set; }

        public int Passengers { get; set; }
    }
}
