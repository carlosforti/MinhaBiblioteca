using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Context.Configurations
{
    public class EditoraViewConfiguration : IEntityTypeConfiguration<EditoraView>
    {
        public void Configure(EntityTypeBuilder<EditoraView> builder)
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

            // builder
            //     .HasMany(x => x.Livros)
            //     .WithOne(x => x.Editora);
        }
    }
}