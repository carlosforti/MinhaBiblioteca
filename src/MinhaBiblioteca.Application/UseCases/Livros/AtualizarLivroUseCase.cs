using System;
using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Livros
{
    public class AtualizarLivroUseCase : IAtualizarLivroUseCase
    {
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly ILivroRepository _livroRepository;
        private readonly IBuscarEditoraPorIdUseCase _buscarEditoraUseCase;
        private readonly IBuscarAutorPorIdUseCase _buscarAutorUseCase;

        public AtualizarLivroUseCase(IMapper mapper,
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

        public async Task<LivroViewModel> Executar(Guid id, AtualizarLivroViewModel atualizarLivroViewModel)
        {
            if (id != atualizarLivroViewModel.Id)
            {
                _notificador.AdicionarErro("id", "Id informado não corresponde ao da rota");
                return null;
            }

            var editora = await _buscarEditoraUseCase.Executar(atualizarLivroViewModel.EditoraId);
            var autor = await _buscarAutorUseCase.Executar(atualizarLivroViewModel.AutorId);
            if (_notificador.ExistemErros) return null;

            var livro = _mapper.Map<Livro>((atualizarLivroViewModel, editora, autor));
            if (livro == null) return null;
            await _livroRepository.AtualizarLivro(livro);

            return _notificador.ExistemErros ? null : _mapper.Map<LivroViewModel>(livro);
        }
    }
}