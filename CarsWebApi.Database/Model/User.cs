using System;
using System.ComponentModel.DataAnnotations;

namespace CarsWebApi.Database.Model
{
    public class User
    {
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
