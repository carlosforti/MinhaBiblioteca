using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.Interfaces.Data.Autor;
using MinhaBiblioteca.Application.UseCases.Autor.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Autor
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

            var autor = _mapper.Map<Domain.Entities.Autor>(autorViewModel);
            autor = await _autorRepository.AtualizarAutor(autor);

            return _mapper.Map<AutorViewModel>(autor);
        }
    }
}