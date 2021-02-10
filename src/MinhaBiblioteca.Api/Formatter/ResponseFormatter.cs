using System.Collections.Generic;
using System.Net;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Application.ViewModels;

namespace MinhaBiblioteca.Api.Formatter
{
    public enum TipoRequisicao
    {
        Get,
        Post,
        Patch,
        Put,
        Delete
    }
    
    public interface IResponseFormatter
    {
        IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, BaseViewModel valor);
        IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, IEnumerable<BaseViewModel> valor);
    }

    public class ResponseFormatter : IResponseFormatter
    {
        private readonly INotificador _notificador;
        public ResponseFormatter(INotificador notificador)
        {
            _notificador = notificador;
        }

        public IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, BaseViewModel valor)
        {
            if (_notificador.TemErros)
            {
                return FormatarErros();
            }
            
            switch (tipoRequisicao)
            {
                case TipoRequisicao.Post:
                    return new CreatedAtRouteResult("Get", new {id = valor.Id}, valor);
                case TipoRequisicao.Put:
                case TipoRequisicao.Patch:
                    return new AcceptedAtRouteResult("Get", new {id = valor.Id}, valor);
                case TipoRequisicao.Delete:
                    return new NoContentResult();
                default:
                    return new OkObjectResult(valor);
            }
        }

        public IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, IEnumerable<BaseViewModel> valor)
        {
            if (_notificador.TemErros)
            {
                return FormatarErros();
            }

            return new OkObjectResult(valor);
        }

        private IActionResult FormatarErros()
        {
            return _notificador.StatusCode switch
            {
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.NotFound => new NotFoundResult(),
                HttpStatusCode.InternalServerError => new StatusCodeResult((int)HttpStatusCode.InternalServerError),
                _ => new BadRequestObjectResult(_notificador.Erros)
            };
        }
    }
}