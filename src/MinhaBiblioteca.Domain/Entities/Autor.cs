using System;

namespace MinhaBiblioteca.Domain.Entities
{
    public class Autor
    {
        public Autor(Guid id, string nome, string email, string pais)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Pais = pais;
        }

        public Guid Id { get; private set; }
        public string Nome { get; }
        public string Email { get; }
        public string Pais { get; }

        // public ICollection<Livro> Livros = new List<Livro>();
        
        public void SetId(Guid newGuid)
        {
            Id = newGuid;
        }
    }
}