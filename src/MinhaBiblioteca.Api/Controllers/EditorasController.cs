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
    [Route("v1/[controller]")]
    public class EditorasController : ControllerBase
    {
        private readonly IResponseFormatter _formatter;
        private readonly ILogger<EditorasController> _logger;
        private readonly IInserirEditoraUseCase _inserirEditoraUseCase;
        private readonly IBuscarEditoraPorIdUseCase _buscarEditoraPorIdUseCase;

        public EditorasController(ILogger<EditorasController> logger,
            IInserirEditoraUseCase inserirEditoraUseCase,
            IBuscarEditoraPorIdUseCase buscarEditoraPorIdUseCase,
            IResponseFormatter formatter)
        {
            _logger = logger;
            _inserirEditoraUseCase = inserirEditoraUseCase;
            _buscarEditoraPorIdUseCase = buscarEditoraPorIdUseCase;
            _formatter = formatter;
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        public async Task Post(InserirEditoraCommand command)
        {
            await _inserirEditoraUseCase.Executar(command);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var editora = await _buscarEditoraPorIdUseCase.Executar(id);

            return _formatter.FormatarResposta(editora);
        } 
    }
}