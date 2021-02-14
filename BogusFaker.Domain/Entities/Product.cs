using System;
using System.Collections.Generic;

namespace BogusFaker.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
