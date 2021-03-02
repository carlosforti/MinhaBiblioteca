using MinhaBiblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaBiblioteca.Infra.Data.Views
{
    public class LivroView
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Edicao { get; private set; }
        public int AutorId { get; set; }
        public Autor Autor { get; private set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; private set; }
    }
}
