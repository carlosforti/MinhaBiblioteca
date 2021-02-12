using System.Collections.Generic;

namespace MinhaBiblioteca.Domain.Entities
{
    public class Autor
    {
        public Autor(int id, string nome, string email, string pais)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Pais = pais;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Pais { get; private set; }

        // public ICollection<Livro> Livros = new List<Livro>();
    }
}