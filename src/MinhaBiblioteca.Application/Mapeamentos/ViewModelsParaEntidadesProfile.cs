using AutoMapper;

using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Mapeamentos
{
    public class ViewModelsParaEntidadesProfile : Profile
    {
        public ViewModelsParaEntidadesProfile()
        {
            CreateMap<InserirEditoraViewModel, Editora>()
                .ConstructUsing((viewModel,
                    context) => new Editora(0,
                    viewModel.Nome,
                    viewModel.Email,
                    viewModel.Pais));

            CreateMap<AtualizarEditoraViewModel, Editora>();

            CreateMap<InserirAutorViewModel, Autor>()
                .ConstructUsing((viewModel, context) => new Autor(0, viewModel.Nome, viewModel.Email, viewModel.Pais));

            CreateMap<AtualizarAutorViewModel, Autor>();

            CreateMap<(AtualizarLivroViewModel, EditoraViewModel, AutorViewModel), Livro>()
                .ConvertUsing((source, destination, context) =>
                {
                    var (atualizarLivroViewModel, editoraViewModel, autorViewModel) = source;
                    if (atualizarLivroViewModel == null || editoraViewModel == null || autorViewModel == null)
                        return null;

                    var livro = new Livro(atualizarLivroViewModel.Id,
                        atualizarLivroViewModel.Nome,
                        atualizarLivroViewModel.Edicao,
                        context.Mapper.Map<Autor>(autorViewModel),
                        context.Mapper.Map<Editora>(editoraViewModel));

                    return livro;
                });
            
            CreateMap<(InserirLivroViewModel, EditoraViewModel, AutorViewModel), Livro>()
                .ConvertUsing((source, destination, context) =>
                {
                    var (inserirLivroViewModel, editoraViewModel, autorViewModel) = source;
                    if (inserirLivroViewModel == null || editoraViewModel == null || autorViewModel == null)
                        return null;

                    var livro = new Livro(0,
                        inserirLivroViewModel.Nome,
                        inserirLivroViewModel.Edicao,
                        context.Mapper.Map<Autor>(autorViewModel),
                        context.Mapper.Map<Editora>(editoraViewModel));

                    return livro;
                });


            CreateMap<AutorViewModel, Autor>();
            CreateMap<EditoraViewModel, Editora>();
        }
    }
}