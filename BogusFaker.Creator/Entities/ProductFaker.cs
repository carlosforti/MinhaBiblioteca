using System;
using System.Collections.Generic;

using Bogus;

using BogusFaker.Domain.Entities;

namespace BogusFaker.Creator.Entities
{
    public static class ProductFaker
    {
        private static string[] Sizes = { "S", "M", "L", "XL" };

        public static Faker<Product> GetProduct()
        {
            return new Faker<Product>()
                .CustomInstantiator(faker => new Product
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Commerce.ProductName(),
                    Color = faker.Commerce.Color(),
                    Size = faker.PickRandom(Sizes)
                });
        }

        public static IEnumerable<Product> GetProducts(int quantity = 1)
        {
            return GetProduct().Generate(quantity);
        }
    }
}