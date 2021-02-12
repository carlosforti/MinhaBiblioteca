using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data.Autor;
using MinhaBiblioteca.Application.UseCases.Autor.Interfaces;

namespace MinhaBiblioteca.Application.UseCases.Autor
{
    public class ExcluirAutorPorIdUseCase : IExcluirAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorCommand _autorCommand;

        public ExcluirAutorPorIdUseCase(IMapper mapper, IAutorCommand autorCommand)
        {
            _mapper = mapper;
            _autorCommand = autorCommand;
        }

        public async Task Executar(int id)
        {
            await _autorCommand.ExcluirAutor(id);
        }
    }
}