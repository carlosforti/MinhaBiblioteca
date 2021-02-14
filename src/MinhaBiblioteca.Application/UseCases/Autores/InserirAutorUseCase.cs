using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data.Autores;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.UseCases.Autores
{
    public class InserirAutorUseCase: IInserirAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorCommand _autorCommand;

        public InserirAutorUseCase(IMapper mapper, IAutorCommand autorCommand)
        {
            _mapper = mapper;
            _autorCommand = autorCommand;
        }

        public async Task<AutorViewModel> Executar(InserirAutorViewModel autorViewModel)
        {
            var autor = _mapper.Map<Autor>(autorViewModel);
            autor = await _autorCommand.InserirAutor(autor);
            return _mapper.Map<AutorViewModel>(autor);
        }
    }
}