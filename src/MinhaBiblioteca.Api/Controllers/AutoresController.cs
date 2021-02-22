using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autores;

namespace MinhaBiblioteca.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IResponseFormatter _responseFormatter;
        private readonly IAtualizarAutorUseCase _atualizarAutorUseCase;
        private readonly IBuscarAutorPorIdUseCase _buscarAutorPorIdUseCase;
        private readonly IExcluirAutorUseCase _excluirAutorUseCase;
        private readonly IInserirAutorUseCase _inserirAutorUseCase;
        private readonly IListarAutoresUseCase _listarAutoresUseCase;

        public AutoresController(IResponseFormatter responseFormatter,
            IAtualizarAutorUseCase atualizarAutorUseCase,
            IBuscarAutorPorIdUseCase buscarAutorPorIdUseCase,
            IExcluirAutorUseCase excluirAutorUseCase,
            IInserirAutorUseCase inserirAutorUseCase,
            IListarAutoresUseCase listarAutoresUseCase)
        {
            _responseFormatter = responseFormatter;
            _atualizarAutorUseCase = atualizarAutorUseCase;
            _buscarAutorPorIdUseCase = buscarAutorPorIdUseCase;
            _excluirAutorUseCase = excluirAutorUseCase;
            _inserirAutorUseCase = inserirAutorUseCase;
            _listarAutoresUseCase = listarAutoresUseCase;
        }

        /// <summary>
        /// Listar todos os autores
        /// </summary>
        /// <returns>Lista de autores cadastrados, ou sem conteúdo, em caso de não encontrar</returns>
        [HttpGet(Order = 1)]
        [ProducesResponseType(typeof(Response<IEnumerable<AutorResumidoViewModel>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            var autores = await _listarAutoresUseCase.Executar();
            return _responseFormatter.FormatarResposta(TipoRequisicao.Get, autores);
        }

        /// <summary>
        /// Buscar o autor do ID informado
        /// </summary>
        /// <param name="id">ID do autor desejado</param>
        /// <returns>Autor, ou sem conteúdo, caso não encontre</returns>
        [HttpGet("{id}", Order = 2)]
        [ProducesResponseType(typeof(Response<AutorViewModel>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await _buscarAutorPorIdUseCase.Executar(id);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Get, autor);
        }

        /// <summary>
        /// Inserir um novo autor
        /// </summary>
        /// <param name="inserirAutorViewModel">Dados do autor a ser inserido</param>
        /// <returns>Autor com o ID gerado para ele</returns>
        [HttpPost(Order = 3)]
        [ProducesResponseType(typeof(Response<AutorViewModel>), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(InserirAutorViewModel inserirAutorViewModel)
        {
            var autor = await _inserirAutorUseCase.Executar(inserirAutorViewModel);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Post, autor);
        }

        /// <summary>
        /// Aturalizar um autor existente
        /// </summary>
        /// <param name="id">ID do autor a ser atualizado</param>
        /// <param name="atualizarAutorViewModel">Daoos do autor para atualização</param>
        /// <returns>Autor com dados atualizados</returns>
        [HttpPut("{id}", Order = 4)]
        [ProducesResponseType(typeof(Response<AutorViewModel>), (int) HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, AtualizarAutorViewModel atualizarAutorViewModel)
        {
            var autor = await _atualizarAutorUseCase.Executar(id, atualizarAutorViewModel);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Put, autor);
        }

        /// <summary>
        /// Excluir o autore do ID informado
        /// </summary>
        /// <param name="id">ID do autor a ser excluído</param>
        /// <returns>Sem conteúudo em caso de sucesso, ou uma requisição inválida</returns>
        [HttpDelete("{id}", Order = 5)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _excluirAutorUseCase.Executar(id);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Delete, null);
        }
    }
}