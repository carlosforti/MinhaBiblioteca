using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.Interfaces.Data.Autor;
using MinhaBiblioteca.Application.UseCases.Autor.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autor;

namespace MinhaBiblioteca.Application.UseCases.Autor
{
    public class ListarAutoresUseCase: IListarAutoresUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorRepository _autorRepository;

        public ListarAutoresUseCase(IMapper mapper, IAutorRepository autorRepository)
        {
            _mapper = mapper;
            _autorRepository = autorRepository;
        }

        public async Task<IEnumerable<AutorResumidoViewModel>> Executar()
        {
            var autores = await _autorRepository.ListarAutores();
            return _mapper.Map<IEnumerable<AutorResumidoViewModel>>(autores);
        }
    }
}