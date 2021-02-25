using FluentAssertions;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Api.Formatter
{
    public class ResponseTest
    {
        [Fact]
        public void QuandoTiverNotificacoes_ResultadoDeveSerNulo_EExisteMensagens()
        {
            var livro = new LivroResumidoViewModel();
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem");
            var response = new Response<LivroResumidoViewModel>(livro, notificador);

            response.Mensagens["erro"].Should().Contain("mensagem");
        }
    }
}