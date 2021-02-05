using System.Net;
using System.Threading.Tasks;
using MinhaBiblioteca.Api.Formatter;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace MinhaBiblioteca.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class EditorasController : ControllerBase
    {
        private readonly IResponseFormatter _formatter;
        private readonly ILogger<EditorasController> _logger;
        private readonly IInserirEditoraUseCase _inserirEditoraUseCase;
        private readonly IBuscarEditoraPorIdUseCase _buscarEditoraPorIdUseCase;
        private readonly IListarEditorasUseCase _listarEditorasUseCase;

        public EditorasController(ILogger<EditorasController> logger,
            IInserirEditoraUseCase inserirEditoraUseCase,
            IBuscarEditoraPorIdUseCase buscarEditoraPorIdUseCase,
            IResponseFormatter formatter, IListarEditorasUseCase listarEditorasUseCase)
        {
            _logger = logger;
            _inserirEditoraUseCase = inserirEditoraUseCase;
            _buscarEditoraPorIdUseCase = buscarEditoraPorIdUseCase;
            _formatter = formatter;
            _listarEditorasUseCase = listarEditorasUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var editoras = await _listarEditorasUseCase.Executar();
            return _formatter.FormatarResposta(TipoRequisicao.GET, editoras);
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var editora = await _buscarEditoraPorIdUseCase.Executar(id);
            return _formatter.FormatarResposta(TipoRequisicao.GET, editora);
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] InserirEditoraCommand command)
        {
            var editora = await _inserirEditoraUseCase.Executar(command);
            return _formatter.FormatarResposta(TipoRequisicao.POST, editora);
            // return CreatedAtRoute("Get", new {id = editora.Id}, editora);
        }
    }
}