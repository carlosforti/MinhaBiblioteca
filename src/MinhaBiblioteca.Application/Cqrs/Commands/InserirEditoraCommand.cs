namespace MinhaBiblioteca.Application.Cqrs.Commands
{
    public class InserirEditoraCommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
    }
}