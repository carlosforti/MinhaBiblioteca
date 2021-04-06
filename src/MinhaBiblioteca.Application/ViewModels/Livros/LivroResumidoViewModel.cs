namespace MinhaBiblioteca.Application.ViewModels.Livros
{
    public class LivroResumidoViewModel: BaseViewModel
    {
        public string Nome { get; set; }
        public int Edicao { get; set; }
        public string NomeAutor { get; set; }
        public string NomeEditora { get; set; }
    }
}