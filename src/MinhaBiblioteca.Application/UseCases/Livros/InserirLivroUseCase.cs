using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Livros
{
    public class InserirLivroUseCase : IInserirLivroUseCase
    {
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly ILivroRepository _livroRepository;
        private readonly IBuscarEditoraPorIdUseCase _buscarEditoraUseCase;
        private readonly IBuscarAutorPorIdUseCase _buscarAutorUseCase;

        public InserirLivroUseCase(IMapper mapper,
            INotificador notificador,
            ILivroRepository livroRepository,
            IBuscarEditoraPorIdUseCase buscarEditoraUseCase,
            IBuscarAutorPorIdUseCase buscarAutorUseCase)
        {
            _mapper = mapper;
            _notificador = notificador;
            _livroRepository = livroRepository;
            _buscarEditoraUseCase = buscarEditoraUseCase;
            _buscarAutorUseCase = buscarAutorUseCase;
        }

        public async Task<LivroViewModel> Executar(InserirLivroViewModel livroViewModel)
        {
            var editora = await _buscarEditoraUseCase.Executar(livroViewModel.EditoraId);
            var autor =await  _buscarAutorUseCase.Executar(livroViewModel.AutorId);
            if (_notificador.ExistemErros) return null;
            
            var livro = _mapper.Map<Livro>((livroViewModel, editora, autor));
            livro = await _livroRepository.InserirLivro(livro);

            return _notificador.ExistemErros ? null : _mapper.Map<LivroViewModel>(livro);
        }
    }
}