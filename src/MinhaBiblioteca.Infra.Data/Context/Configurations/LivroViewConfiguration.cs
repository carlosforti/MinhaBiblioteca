using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Context.Configurations
{
    public class LivroViewConfiguration : IEntityTypeConfiguration<LivroView>
    {
        public void Configure(EntityTypeBuilder<LivroView> builder)
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
                .Property(x => x.Edicao)
                .IsRequired();

            builder
                .Property(x => x.AutorId)
                .IsRequired();

            builder
                .Property(x => x.EditoraId)
                .IsRequired();

            // builder
            //     .Ignore(x => x.Autor);
            //
            // builder
            //     .Ignore(x => x.Editora);
        }
    }
}
