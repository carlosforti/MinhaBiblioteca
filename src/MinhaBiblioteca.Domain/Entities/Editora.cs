using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;

namespace MinhaBiblioteca.Domain.Entities
{
    public class Editora
    {
        public Editora(int id, string nome, string email, string pais)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Pais = pais;
        }

        public int Id { get; protected set; }
        public string Nome { get; protected  set; }
        public string Email { get; protected  set; }
        public string Pais { get; protected  set; }
        
        // public ICollection<Livro> Livros = new List<Livro>();
    }
}