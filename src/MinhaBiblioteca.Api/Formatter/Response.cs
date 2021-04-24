using System.Collections.Generic;
using System.Linq;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.API.Formatter
{
    public class Response<T>
    {
        private readonly Dictionary<string, IList<string>> _mensagens = new();
        
        public T Retorno { get; }
        public IReadOnlyDictionary<string, IList<string>> Mensagens => _mensagens;

        public Response(T retorno, INotificador notificador)
        {
            Retorno = retorno;
            GerarLista(notificador);
        }

        private void GerarLista(INotificador notificador)
        {
            var notificacoes = notificador.Erros
                .Concat(notificador.Avisos)
                .ToList();

            notificacoes.ForEach(notificacao => { AdicionarMensagem(notificacao.Propriedade, notificacao.Mensagem); });
        }

        private void AdicionarMensagem(string propriedade, string mensagem)
        {
            if (!_mensagens.ContainsKey(propriedade))
                _mensagens.Add(propriedade, new List<string> {mensagem});
            else
                _mensagens[propriedade].Add(mensagem);
        }
    }
}