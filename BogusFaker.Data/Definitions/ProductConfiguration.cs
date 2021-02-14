using BogusFaker.Creator.Entities;
using BogusFaker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BogusFaker.Data.Definitions
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Color)
                .HasMaxLength(100);

            builder.Property(p => p.Size)
                .HasMaxLength(10);

            builder.HasData(ProductFaker.GetProducts(1000));
        }
    }
}