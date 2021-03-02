using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext([NotNull] DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LivroView> Livros { get; set; }
    }
}