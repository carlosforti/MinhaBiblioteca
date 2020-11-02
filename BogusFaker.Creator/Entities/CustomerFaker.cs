using System;
using System.Collections.Generic;

using Bogus;

using BogusFaker.Domain.Entities;

namespace BogusFaker.Creator.Entities
{
    public static class CustomerFaker
    {
        public static Faker<Customer> GetCustomer()
        {
            return new Faker<Customer>()
                .CustomInstantiator(faker =>
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        FirstName = faker.Person.FirstName,
                        LastName = faker.Person.LastName,
                        DateOfBirth = faker.Person.DateOfBirth,
                        Email = faker.Person.Email,
                        Phone = faker.Person.Phone
                    });
        }

        public static IEnumerable<Customer> GetCustomers(int quantity = 1)
        {
            return GetCustomer().Generate(quantity);
        }
    }
}
