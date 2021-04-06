using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EditoraView> Editoras { get; set; }
        public DbSet<AutorView> Autores { get; set; }
        public DbSet<LivroView> Livros { get; set; }
    }
}