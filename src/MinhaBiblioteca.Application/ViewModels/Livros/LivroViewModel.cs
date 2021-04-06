using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.Application.ViewModels.Livros
{
    public class LivroViewModel: BaseViewModel
    {
        public string Nome { get; set; }
        public int Edicao { get; set; }
        public AutorResumidoViewModel Autor { get; set; }
        public EditoraResumidaViewModel Editora { get; set; }

    }
}