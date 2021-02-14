using System.Collections.Generic;
using System.Linq;
using System.Net;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Application.ViewModels;

namespace MinhaBiblioteca.Api.Formatter
{
    public class Response<T>
    {
        public Response(T retorno, INotificador notificador)
        {
            Retorno = retorno;
            _notificador = notificador;
        }

        private readonly INotificador _notificador;
        public T Retorno { get; }
        public IReadOnlyCollection<Notificacao> Avisos => _notificador?.Avisos?.ToList();
        public IReadOnlyCollection<Notificacao> Erros => _notificador?.Erros?.ToList();
    }

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
        IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, object valor);
        IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, IEnumerable<object> valor);
    }

    public class ResponseFormatter : IResponseFormatter
    {
        private readonly INotificador _notificador;

        public ResponseFormatter(INotificador notificador)
        {
            _notificador = notificador;
        }

        public IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, object valor)
        {
            if (_notificador.TemErros)
            {
                return FormatarErros();
            }

            var retorno = new Response<object>(valor, _notificador);

            switch (tipoRequisicao)
            {
                case TipoRequisicao.Post:
                    return new CreatedAtRouteResult("Get", new {id = ((BaseViewModel) valor).Id}, retorno);
                case TipoRequisicao.Put:
                case TipoRequisicao.Patch:
                    return new AcceptedAtRouteResult("Get", new {id = ((BaseViewModel) valor).Id}, retorno);
                case TipoRequisicao.Delete:
                    return new NoContentResult();
                default:
                    return new OkObjectResult(valor);
            }
        }

        public IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, IEnumerable<object> valor)
        {
            if (_notificador.TemErros)
                return FormatarErros();

            if (valor == null || !valor.Any())
                return new NoContentResult();
            
            var retorno = new Response<object>(valor, _notificador);
            return new OkObjectResult(retorno);
        }

        private IActionResult FormatarErros()
        {
            return _notificador.StatusCode switch
            {
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.NotFound => new NotFoundResult(),
                HttpStatusCode.InternalServerError => new StatusCodeResult((int) HttpStatusCode.InternalServerError),
                _ => new BadRequestObjectResult(_notificador.Erros)
            };
        }
    }
}