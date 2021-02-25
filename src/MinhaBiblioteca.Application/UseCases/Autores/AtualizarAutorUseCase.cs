using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Autores
{
    public class AtualizarAutorUseCase: IAtualizarAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorRepository _autorRepository;
        private readonly INotificador _notificador;

        public AtualizarAutorUseCase(IMapper mapper, IAutorRepository autorRepository, INotificador notificador)
        {
            _mapper = mapper;
            _autorRepository = autorRepository;
            _notificador = notificador;
        }

        public async Task<AutorViewModel> Executar(int id, AtualizarAutorViewModel autorViewModel)
        {
            if (autorViewModel.Id != id)
            {
                _notificador.AdicionarErro("id", "Id informado não corresponde ao da rota");
                return null;
            }

            var autor = _mapper.Map<Autor>(autorViewModel);
            autor = await _autorRepository.AtualizarAutor(autor);

            return _mapper.Map<AutorViewModel>(autor);
        }
    }
}