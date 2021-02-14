using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.ViewModels.Livros
{
    public class LivroViewModel
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public int Edicao { get;  set; }
        public AutorResumidoViewModel Autor { get;  set; }
        public EditoraResumidaViewModel Editora { get;  set; }

    }
}