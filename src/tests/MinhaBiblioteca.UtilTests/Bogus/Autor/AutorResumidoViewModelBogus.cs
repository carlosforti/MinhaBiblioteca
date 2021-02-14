using System.Collections.Generic;
using System.Linq;
using MinhaBiblioteca.Application.ViewModels.Autor;

namespace MinhaBiblioteca.UtilTests.Bogus.Autor
{
    public static class AutorResumidoViewModelBogus
    {
        public static AutorResumidoViewModel ConverterDeAutor(Domain.Entities.Autor autor)
        {
            return new AutorResumidoViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome
            };
        }

        public static IEnumerable<AutorResumidoViewModel> ConverterListaDeAutores(
            IEnumerable<Domain.Entities.Autor> autores)
        {
            return autores.Select(ConverterDeAutor);
        }
    }
}