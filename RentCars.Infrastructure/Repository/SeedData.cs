using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Core.Models;

namespace RentCar.Infrastructure.Repository
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            RentCarsDbContext context = app.ApplicationServices
                .GetRequiredService<RentCarsDbContext>();
            context.Database.Migrate();
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Hyundai,
                        Model = "Accent",
                        Transmission = Transmissions.Automatic,
                        Passengers = 4,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.4,
                        Price = 40
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.VW,
                        Model = "UP",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.0,
                        Price = 33
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Honda,
                        Model = "CR-V",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.5,
                        Price = 55
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.BMW,
                        Model = "X5",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Diesel,
                        Engine = 3.0,
                        Price = 250
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Ford,
                        Model = "Fiesta",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.6,
                        Price = 35
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Kia,
                        Model = "Rio",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.6,
                        Price = 49
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Nissan,
                        Model = "Juke",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.6,
                        Price = 55
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Opel,
                        Model = "Corsa",
                        Transmission = Transmissions.Mechanic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.4,
                        Price = 35
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Peugeot,
                        Model = "301",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Diesel,
                        Engine = 1.6,
                        Price = 40
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Ravon,
                        Model = "R2",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.3,
                        Price = 30
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Skoda,
                        Model = "Fabia",
                        Transmission = Transmissions.Mechanic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.6,
                        Price = 33
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Skoda,
                        Model = "Octavia",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.6,
                        Price = 49
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.Suzuki,
                        Model = "Vitara",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.6,
                        Price = 55
                    },
                    new Car
                    {
                        CarId = Guid.NewGuid(),
                        Brand = Brands.VW,
                        Model = "Polo",
                        Transmission = Transmissions.Automatic,
                        Passengers = 5,
                        TypeEngine = TypeEngines.Petrol,
                        Engine = 1.4,
                        Price = 40
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
