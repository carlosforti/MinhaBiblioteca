using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.API.Controllers
{
    /// <summary>
    /// Controller das editoras
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EditorasController : ControllerBase
    {
        private readonly IResponseFormatter _formatter;
        private readonly IBuscarEditoraPorIdUseCase _buscarEditoraPorIdUseCase;
        private readonly IListarEditorasUseCase _listarEditorasUseCase;
        private readonly IInserirEditoraUseCase _inserirEditoraUseCase;
        private readonly IAtualizarEditoraUseCase _atualizarEditoraUseCase;
        private readonly IExcluirEditoraUseCase _excluirEditoraUseCase;

        public EditorasController(IInserirEditoraUseCase inserirEditoraUseCase,
            IBuscarEditoraPorIdUseCase buscarEditoraPorIdUseCase,
            IResponseFormatter formatter,
            IListarEditorasUseCase listarEditorasUseCase,
            IAtualizarEditoraUseCase atualizarEditoraUseCase,
            IExcluirEditoraUseCase excluirEditoraUseCase)
        {
            _inserirEditoraUseCase = inserirEditoraUseCase;
            _buscarEditoraPorIdUseCase = buscarEditoraPorIdUseCase;
            _formatter = formatter;
            _listarEditorasUseCase = listarEditorasUseCase;
            _atualizarEditoraUseCase = atualizarEditoraUseCase;
            _excluirEditoraUseCase = excluirEditoraUseCase;
        }

        /// <summary>
        /// Listar todas as editoras
        /// </summary>
        /// <returns>Lista de editoras cadastradas</returns>
        [HttpGet(Order = 1)]
        [ProducesResponseType(typeof(Response<IEnumerable<EditoraResumidaViewModel>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<IActionResult> Get()
        {
            var editoras = await _listarEditorasUseCase.Executar();
            return _formatter.FormatarResposta(TipoRequisicao.Get, editoras);
        }

        /// <summary>
        /// Buscar uma editora pelo id informado
        /// </summary>
        /// <param name="id">Id da editora</param>
        /// <returns>Editora com o Id informado</returns>
        [HttpGet("{id}", Name = "Get", Order = 2)]
        [ProducesResponseType(typeof(Response<EditoraViewModel>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetById(int id)
        {
            var editora = await _buscarEditoraPorIdUseCase.Executar(id);
            return _formatter.FormatarResposta(TipoRequisicao.Get, editora);
        }

        /// <summary>
        /// Insere a editora informada na requisição
        /// </summary>
        /// <param name="viewModel">Dados da editora a ser inserida</param>
        /// <returns>Editora inserida com o Id criado para ela</returns>
        [HttpPost(Order = 3)]
        [ProducesResponseType(typeof(Response<EditoraViewModel>), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] InserirEditoraViewModel viewModel)
        {
            var editora = await _inserirEditoraUseCase.Executar(viewModel);
            return _formatter.FormatarResposta(TipoRequisicao.Post, editora);
        }

        [HttpPut("{id}", Order = 4)]
        [ProducesResponseType(typeof(Response<EditoraViewModel>), (int) HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarEditoraViewModel viewModel)
        {
            var editora = await _atualizarEditoraUseCase.Executar(id, viewModel);
            return _formatter.FormatarResposta(TipoRequisicao.Put, editora);
        }

        /// <summary>
        /// Excluir a editora pelo Id informado
        /// </summary>
        /// <param name="id">Id da editora a ser excluída</param>
        /// <returns>Resposta da exclusão</returns>
        [HttpDelete("{id}", Order = 5)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Response<>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _excluirEditoraUseCase.Executar(id);
            return _formatter.FormatarResposta(TipoRequisicao.Delete, null);
        }
    }
}