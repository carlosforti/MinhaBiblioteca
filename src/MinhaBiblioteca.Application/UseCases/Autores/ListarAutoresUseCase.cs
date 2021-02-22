using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Autores
{
    public class ListarAutoresUseCase : IListarAutoresUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorRepository _autorRepository;
        private readonly INotificador _notificador;

        public ListarAutoresUseCase(IMapper mapper, IAutorRepository autorRepository, INotificador notificador)
        {
            _mapper = mapper;
            _autorRepository = autorRepository;
            _notificador = notificador;
        }

        public async Task<IEnumerable<AutorResumidoViewModel>> Executar()
        {
            var autores = await _autorRepository.ListarAutores();
            return _notificador.ExistemErros
                ? new List<AutorResumidoViewModel>()
                : _mapper.Map<IEnumerable<AutorResumidoViewModel>>(autores);
        }
    }
}