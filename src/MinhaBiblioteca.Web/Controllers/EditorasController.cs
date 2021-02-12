using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Application.Interfaces.Data.Editora;

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
