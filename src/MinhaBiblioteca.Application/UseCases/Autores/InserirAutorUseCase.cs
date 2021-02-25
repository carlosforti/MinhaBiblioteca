using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.UseCases.Autores
{
    public class InserirAutorUseCase: IInserirAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorRepository _autorRepository;

        public InserirAutorUseCase(IMapper mapper, IAutorRepository autorRepository)
        {
            _mapper = mapper;
            _autorRepository = autorRepository;
        }

        public async Task<AutorViewModel> Executar(InserirAutorViewModel autorViewModel)
        {
            var autor = _mapper.Map<Autor>(autorViewModel);
            autor = await _autorRepository.InserirAutor(autor);
            return _mapper.Map<AutorViewModel>(autor);
        }
    }
}