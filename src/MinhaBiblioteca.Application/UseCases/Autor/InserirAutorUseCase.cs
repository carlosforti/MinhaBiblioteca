using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data.Autor;
using MinhaBiblioteca.Application.UseCases.Autor.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autor;

namespace MinhaBiblioteca.Application.UseCases.Autor
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
            var autor = _mapper.Map<Domain.Entities.Autor>(autorViewModel);
            autor = await _autorCommand.InserirAutor(autor);
            return _mapper.Map<AutorViewModel>(autor);
        }
    }
}