using System;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Infra.Data.Views
{
    public class LivroView: BaseView
    {
        public string Nome { get; set; }
        public int Edicao { get; set; }
        public Guid AutorId { get; set; }
        public AutorView Autor { get; set; }
        public Guid EditoraId { get; set; }
        public EditoraView Editora { get; set; }
    }
}
