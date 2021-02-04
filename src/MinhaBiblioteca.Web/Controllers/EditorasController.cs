using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace MinhaBiblioteca.Web.Controllers
{
    public class EditorasController : Controller
    {
        private readonly IEditoraCommand editoraCommand;
        private readonly IEditoraQuery editoraQuery;

        public EditorasController(IEditoraCommand editoraCommand, IEditoraQuery editoraQuery)
        {
            this.editoraCommand = editoraCommand;
            this.editoraQuery = editoraQuery;
        }

        public async Task<IActionResult> Index()
        {
            var editoras = await editoraQuery.ListarEditoras();
            return View(editoras);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var editora = await editoraQuery.BuscarEditora(id);
            return View(editora);
        }
    }
}
