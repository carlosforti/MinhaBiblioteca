using BogusFaker.Creator.Entities;
using BogusFaker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BogusFaker.Data.Definitions
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Costumers");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => new { c.FirstName, c.LastName });

            builder.Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.DateOfBirth)
                .HasColumnType("Date");

            builder.Property(c => c.Email)
                .HasMaxLength(150);

            builder.Property(c => c.Phone)
                .HasMaxLength(20)
                .HasMaxLength(20);

            builder.HasData(CustomerFaker.GetCustomers(100));
        }
    }
}