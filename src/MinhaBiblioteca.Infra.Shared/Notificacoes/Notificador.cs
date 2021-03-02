using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MinhaBiblioteca.Infra.Shared.Notificacoes
{
    public interface INotificador
    {
        IReadOnlyList<Notificacao> Erros { get; }
        IReadOnlyList<Notificacao> Avisos { get; }
        bool ExistemErros { get; }
        HttpStatusCode StatusCode { get; }
        void AdicionarErro(string propriedade, string mensagem);
        void AdicionarAviso(string propriedade, string mensagem);
        void AdicionarErro(string propriedade, string mensagem, HttpStatusCode statusCode);
        void DefinirStatusCode(HttpStatusCode badRequest);
    }

    public class Notificador : INotificador
    {
        public HttpStatusCode StatusCode { get; private set; }

        private readonly List<Notificacao> _notificacoes = new List<Notificacao>();

        public IReadOnlyList<Notificacao> Erros =>
            _notificacoes.Where(x => x.TipoNotificacao == TipoNotificacao.Erro).ToList();

        public IReadOnlyList<Notificacao> Avisos =>
            _notificacoes.Where(x => x.TipoNotificacao == TipoNotificacao.Aviso).ToList();

        public bool ExistemErros => _notificacoes.Any(x => x.TipoNotificacao == TipoNotificacao.Erro);

        public void AdicionarErro(string propriedade, string mensagem, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            _notificacoes.Add(new Notificacao(TipoNotificacao.Erro, propriedade, mensagem));
        }

        public void AdicionarErro(string propriedade, string mensagem)
        {
            _notificacoes.Add(new Notificacao(TipoNotificacao.Erro, propriedade, mensagem));
        }

        public void AdicionarAviso(string propriedade, string mensagem) =>
            _notificacoes.Add(new Notificacao(TipoNotificacao.Aviso, propriedade, mensagem));

        public void DefinirStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}