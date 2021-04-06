using System;

namespace MinhaBiblioteca.Domain.Entities
{
    public class Editora
    {
        public Editora(Guid id, string nome, string email, string pais)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Pais = pais;
        }

        public Guid Id { get; protected set; }
        public string Nome { get; protected  set; }
        public string Email { get; protected  set; }
        public string Pais { get; protected  set; }
        
        // public ICollection<Livro> Livros = new List<Livro>();
    }
}