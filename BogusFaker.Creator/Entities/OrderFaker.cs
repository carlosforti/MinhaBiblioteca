using System;
using System.Collections.Generic;
using System.Linq;

using Bogus;

using BogusFaker.Domain.Entities;

namespace BogusFaker.Creator.Entities
{
    public static class OrderFaker
    {
        public static Faker<Order> GetOrder()
        {
            return new Faker<Order>()
                .CustomInstantiator(faker =>
                {
                    var customer = CustomerFaker.GetCustomer().Generate();
                    var products = ProductFaker.GetProducts(10);
                    var orderId = Guid.NewGuid();
                    var orderItems = products?.ToList().Select(product => new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        OrderId = orderId,
                        Product = product,
                        ProductId = product.Id
                    }).ToList();

                    return new Order()
                    {
                        Id = orderId,
                        CustomerId = customer.Id,
                        Customer = customer,
                        OrderItems = orderItems
                    };
                });
        }

        public static IEnumerable<Order> GetOrders(int quantity = 1)
        {
            return GetOrder().Generate(quantity);
        }
    }
}