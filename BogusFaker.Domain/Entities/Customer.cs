using System;
using System.Collections.Generic;

namespace BogusFaker.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                    age -= 1;

                return age;
            }
        }

        public IEnumerable<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FullName}\n" +
                   $"Date of birth: {DateOfBirth:d}\n" +
                   $"Email: {Email}\n" +
                   $"Phone: {Phone}";
        }
    }
}