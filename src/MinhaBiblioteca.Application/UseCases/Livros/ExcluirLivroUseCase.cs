using System.Threading.Tasks;

using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;

namespace MinhaBiblioteca.Application.UseCases.Livros
{
    public class ExcluirLivroUseCase : IExcluirLivroUseCase
    {
        private readonly ILivroRepository _livroRepository;

        public ExcluirLivroUseCase(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task Executar(int id)
        {
            await _livroRepository.ExcluirLivro(id);
        }
    }
}