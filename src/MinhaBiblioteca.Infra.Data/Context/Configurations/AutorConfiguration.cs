using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaBiblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaBiblioteca.Infra.Data.Context.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(200);

            builder
                .Property(x => x.Pais)
                .HasMaxLength(200);
        }
    }
}
