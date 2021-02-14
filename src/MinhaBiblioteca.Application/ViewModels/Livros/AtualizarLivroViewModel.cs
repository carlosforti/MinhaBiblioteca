using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.ViewModels.Livros
{
    public class AtualizarLivroViewModel
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public int Edicao { get;  set; }
        public int AutorId { get;  set; }
        public int EditoraId { get;  set; }
    }
}