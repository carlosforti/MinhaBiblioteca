using System;

namespace MinhaBiblioteca.Application.ViewModels.Livros
{
    public class InserirLivroViewModel
    {
        public string Nome { get;  set; }
        public int Edicao { get;  set; }
        public Guid AutorId { get;  set; }
        public Guid EditoraId { get;  set; }
    }
}