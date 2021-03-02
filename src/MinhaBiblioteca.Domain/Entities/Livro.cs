namespace MinhaBiblioteca.Domain.Entities
{
    public class Livro
    {
        public Livro(int id, string nome, int edicao, Autor autor, Editora editora)
        {
            Id = id;
            Nome = nome;
            Edicao = edicao;
            Autor = autor;
            Editora = editora;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Edicao { get; private set; }

        public Autor Autor { get; private set; }
        public Editora Editora { get; private set; }
    }
}