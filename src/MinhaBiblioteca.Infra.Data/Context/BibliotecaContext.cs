using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LivroView> Livros { get; set; }

        public BibliotecaContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public override EntityEntry<T> Entry<T>(T entity)
            where T : class
        {
            return base.Entry<T>(entity);
        }

        public new void Remove<T>(T entity) where T : class
        {
            base.Remove(entity);
        }
    }
}