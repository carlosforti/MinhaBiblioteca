using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Infra.Data.Views
{
    public class LivroView: BaseView
    {
        public string Nome { get; set; }
        public int Edicao { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
    }
}
