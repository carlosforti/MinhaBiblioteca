using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Autores
{
    public class BuscarAutorPorIdUseCase: IBuscarAutorPorIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorRepository _autorRepository;
        private readonly INotificador _notificador;

        public BuscarAutorPorIdUseCase(IMapper mapper, IAutorRepository autoreRepository, INotificador notificador)
        {
            _mapper = mapper;
            _autorRepository = autoreRepository;
            _notificador = notificador;
        }

        public async Task<AutorViewModel> Executar(int id)
        {
            var autor = await _autorRepository.BuscarAutorPorId(id);
            return _notificador.ExistemErros ? null : _mapper.Map<AutorViewModel>(autor);
        }
    }
}