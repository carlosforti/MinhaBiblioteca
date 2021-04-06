using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Api.Formatter
{
    public class ResponseFormatterTest
    {
        [Fact]
        public void FormatarResposta_ComErroSemStatusCode_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem");
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeInternalServerError_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.InternalServerError);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNoContent_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NoContent);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNotFound_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NotFound);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NotFound);
        }

        [Fact]
        public void FormatarResposta_ComErroSemStatusCode_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem");
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeInternalServerError_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.InternalServerError);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNoContent_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NoContent);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNotFound_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NotFound);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NotFound);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_GET()
        {
            var notificador = new Notificador();
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };
            var esperado = new Response<EditoraViewModel>(editora, notificador);
                

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);
            resultado.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(esperado);

            resultado.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_GET_Lista()
        {
            var notificador = new Notificador();
            var responseFormatter = new ResponseFormatter(notificador);
            var editoras = new List<EditoraViewModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resposta = new Response<IEnumerable<EditoraViewModel>>(editoras, notificador);

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editoras);
            resultado.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(resposta);

            resultado.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }

        [Fact]
        public void FormatarResposta_SemRetorno_TipoRequisicao_GET_Lista()
        {
            var notificador = new Notificador();
            var responseFormatter = new ResponseFormatter(notificador);
            var editoras = new List<EditoraViewModel>();

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editoras);
            resultado.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_POST()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var esperado = new Response<EditoraViewModel>(editora, notificador);

            var resultado = formatter.FormatarResposta(TipoRequisicao.Post, editora);

            resultado.Should().BeOfType<CreatedResult>()
                .Which.Value.Should().BeEquivalentTo(esperado);

            resultado.Should().BeOfType<CreatedResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.Created);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_PUT()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var esperado = new Response<EditoraViewModel>(editora, notificador);

            var resultado = formatter.FormatarResposta(TipoRequisicao.Put, editora);

            resultado.Should().BeOfType<AcceptedResult>()
                .Which.Value.Should().BeEquivalentTo(esperado);

            resultado.Should().BeOfType<AcceptedResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.Accepted);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_PATCH()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resposta = new Response<EditoraViewModel>(editora, notificador);

            var resultado = formatter.FormatarResposta(TipoRequisicao.Patch, editora);

            resultado.Should().BeOfType<AcceptedResult>()
                .Which.Value.Should().BeEquivalentTo(resposta);

            resultado.Should().BeOfType<AcceptedResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.Accepted);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_DELETE()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = formatter.FormatarResposta(TipoRequisicao.Delete, editora);

            resultado.Should().BeOfType<NoContentResult>();
        }
    }
}