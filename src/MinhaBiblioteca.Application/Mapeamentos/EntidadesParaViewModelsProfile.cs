using AutoMapper;

using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Mapeamentos
{
    public class EntidadesParaViewModelsProfile : Profile
    {
        public EntidadesParaViewModelsProfile()
        {
            CreateMap<Editora, EditoraViewModel>();
            CreateMap<Editora, EditoraResumidaViewModel>();
            CreateMap<Autor, AutorViewModel>();
            CreateMap<Autor, AutorResumidoViewModel>();
            CreateMap<Livro, LivroViewModel>()
                .ConvertUsing((source, destination, context) =>
                    new LivroViewModel
                    {
                        Id = source.Id,
                        Nome = source.Nome,
                        Edicao = source.Edicao,
                        Autor = context.Mapper.Map<AutorResumidoViewModel>(source.Autor),
                        Editora = context.Mapper.Map<EditoraResumidaViewModel>(source.Editora)
                    }
                );
            CreateMap<Livro, LivroResumidoViewModel>()
                .ConvertUsing((source, destination, context) =>
                    new LivroResumidoViewModel
                    {
                        Id = source.Id,
                        Nome = source.Nome,
                        Edicao = source.Edicao,
                        NomeAutor = source.Autor.Nome,
                        NomeEditora = source.Editora.Nome
                    });
        }
    }
}