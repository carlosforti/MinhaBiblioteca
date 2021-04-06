using System;

namespace MinhaBiblioteca.Domain.Entities
{
    public class Livro
    {
        public Livro(Guid id, string nome, int edicao, Autor autor, Editora editora)
        {
            Id = id;
            Nome = nome;
            Edicao = edicao;
            Autor = autor;
            Editora = editora;
        }

        public Guid Id { get; }
        public string Nome { get; }
        public int Edicao { get; }

        public Autor Autor { get; }
        public Editora Editora { get; }
    }
}