using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Livros;

namespace MinhaBiblioteca.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly IResponseFormatter _responseFormatter;
        private readonly IListarLivrosUseCase _listarLivrosUseCase;
        private readonly IBuscarLivroPorIdUseCase _buscarLivroPorIdUseCase;
        private readonly IInserirLivroUseCase _inserirLivroUseCase;
        private readonly IAtualizarLivroUseCase _atualizarLivroUseCase;
        private readonly IExcluirLivroUseCase _excluirLivroUseCase;

        public LivrosController(IResponseFormatter responseFormatter, 
            IListarLivrosUseCase listarLivrosUseCase,
            IBuscarLivroPorIdUseCase buscarLivroPorIdUseCase,
            IInserirLivroUseCase inserirLivroUseCase,
            IAtualizarLivroUseCase atualizarLivroUseCase,
            IExcluirLivroUseCase excluirLivroUseCase)
        {
            _responseFormatter = responseFormatter;
            _listarLivrosUseCase = listarLivrosUseCase;
            _buscarLivroPorIdUseCase = buscarLivroPorIdUseCase;
            _inserirLivroUseCase = inserirLivroUseCase;
            _atualizarLivroUseCase = atualizarLivroUseCase;
            _excluirLivroUseCase = excluirLivroUseCase;
        }
        
        /// <summary>
        /// Listar todos os livros
        /// </summary>
        /// <returns>Lista de livros cadastrados</returns>
        [HttpGet(Order = 1)]
        [ProducesResponseType(typeof(Response<IEnumerable<LivroResumidoViewModel>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<IEnumerable<LivroResumidoViewModel>> Get()
        {
            var livros = await _listarLivrosUseCase.Executar();
            return livros;
        }

        /// <summary>
        /// Buscar um livro pelo id informado
        /// </summary>
        /// <param name="id">Id do livro</param>
        /// <returns>Livro com o Id informado</returns>
        [HttpGet("{id}", Name = "Get", Order = 2)]
        [ProducesResponseType(typeof(Response<LivroViewModel>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetById(int id)
        {
            var editora = await _buscarLivroPorIdUseCase.Executar(id);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);
        }

        /// <summary>
        /// Insere o livro informado na requisição
        /// </summary>
        /// <param name="viewModel">Dados do livro a ser inserido</param>
        /// <returns>Livro inserido, com o Id criado para ele</returns>
        [HttpPost(Order = 3)]
        [ProducesResponseType(typeof(Response<LivroViewModel>), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] InserirLivroViewModel viewModel)
        {
            var editora = await _inserirLivroUseCase.Executar(viewModel);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Post, editora);
        }

        /// <summary>
        /// Atualiza o livro informado na requisição e no id enviado
        /// </summary>
        /// <param name="id">Id do livro a ser alterado</param>
        /// <param name="viewModel">Dados do livro a ser alterado</param>
        /// <returns>Livro alterado, ou nulo e mensagens de erro</returns>
        [HttpPut("{id}", Order = 4)]
        [ProducesResponseType(typeof(Response<LivroViewModel>), (int) HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarLivroViewModel viewModel)
        {
            var editora = await _atualizarLivroUseCase.Executar(id, viewModel);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Put, editora);
        }

        /// <summary>
        /// Excluir o livro pelo Id informado
        /// </summary>
        /// <param name="id">Id do livro a ser excluído</param>
        /// <returns>Resposta da exclusão</returns>
        [HttpDelete("{id}", Order = 5)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _excluirLivroUseCase.Executar(id);
            return _responseFormatter.FormatarResposta(TipoRequisicao.Delete, null);
        }
    }
}
