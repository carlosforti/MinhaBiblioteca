using System;

using BogusFaker.Domain.Entities;

using FluentAssertions;

using Xunit;

namespace BogusFaker.UnitTests.Domain
{
    public class CustomerTests
    {
        [Fact]
        public void CompleteAge()
        {
            const int age = 20;
            var dateOfBirth = DateTime.Now.AddYears(age * -1);
            var customer = new Customer(Guid.Empty, "", "", dateOfBirth, "", "");
            age.Should().Be(customer.Age);
        }

        [Fact]
        public void IncompleteAge()
        {
            const int age = 20;
            var dateOfBirth = DateTime.Now.AddYears(age * -1).AddMonths(2);
            var customer = new Customer(Guid.Empty, "", "", dateOfBirth, "", "");
            age.Should().BeGreaterThan(customer.Age);
        }
    }
}
