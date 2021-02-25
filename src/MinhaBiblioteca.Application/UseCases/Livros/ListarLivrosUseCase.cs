using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Livros
{
    public class ListarLivrosUseCase : IListarLivrosUseCase
    {
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly ILivroRepository _livroRepository;

        public ListarLivrosUseCase(IMapper mapper, INotificador notificador, ILivroRepository livroRepository)
        {
            _mapper = mapper;
            _notificador = notificador;
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<LivroResumidoViewModel>> Executar()
        {
            var livros = await _livroRepository.ListarLivros();
            return _notificador.ExistemErros ? null : _mapper.Map<IEnumerable<LivroResumidoViewModel>>(livros);
        }
    }
}