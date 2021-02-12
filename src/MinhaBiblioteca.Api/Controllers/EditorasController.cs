using System.Net;
using System.Threading.Tasks;
using MinhaBiblioteca.Api.Formatter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaBiblioteca.Application.UseCases.Editora.Interfaces;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Application.ViewModels.Editora;


namespace MinhaBiblioteca.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class EditorasController : ControllerBase
    {
        private readonly IResponseFormatter _formatter;
        private readonly ILogger<EditorasController> _logger;
        private readonly IBuscarEditoraPorIdUseCase _buscarEditoraPorIdUseCase;
        private readonly IListarEditorasUseCase _listarEditorasUseCase;
        private readonly IInserirEditoraUseCase _inserirEditoraUseCase;
        private readonly IAtualizarEditoraUseCase _atualizarEditoraUseCase;
        private readonly IExcluirEditoraUseCase _excluirEditoraUseCase;

        public EditorasController(ILogger<EditorasController> logger,
            IInserirEditoraUseCase inserirEditoraUseCase,
            IBuscarEditoraPorIdUseCase buscarEditoraPorIdUseCase,
            IResponseFormatter formatter, IListarEditorasUseCase listarEditorasUseCase, IAtualizarEditoraUseCase atualizarEditoraUseCase, IExcluirEditoraUseCase excluirEditoraUseCase)
        {
            _logger = logger;
            _inserirEditoraUseCase = inserirEditoraUseCase;
            _buscarEditoraPorIdUseCase = buscarEditoraPorIdUseCase;
            _formatter = formatter;
            _listarEditorasUseCase = listarEditorasUseCase;
            _atualizarEditoraUseCase = atualizarEditoraUseCase;
            _excluirEditoraUseCase = excluirEditoraUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var editoras = await _listarEditorasUseCase.Executar();
            return _formatter.FormatarResposta(TipoRequisicao.Get, editoras);
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var editora = await _buscarEditoraPorIdUseCase.Executar(id);
            return _formatter.FormatarResposta(TipoRequisicao.Get, editora);
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] InserirEditoraViewModel viewModel)
        {
            var editora = await _inserirEditoraUseCase.Executar(viewModel);
            return _formatter.FormatarResposta(TipoRequisicao.Post, editora);
        }
        
        [HttpPatch("{id}")]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Patch(int id, [FromBody] AtualizarEditoraViewModel viewModel)
        {
            var editora = await _atualizarEditoraUseCase.Executar(id, viewModel);
            return _formatter.FormatarResposta(TipoRequisicao.Patch, editora);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _excluirEditoraUseCase.Executar(id);
            return _formatter.FormatarResposta(TipoRequisicao.Delete, null as BaseViewModel);
        }
    }
}