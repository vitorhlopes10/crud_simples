using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using crud_simples.Models;
using crud_simples.Services;
using crud_simples.Models.ViewModels;

namespace crud_simples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClienteService service;
        public HomeController(ClienteService context)
        {
            service = context;
        }

        public IActionResult Index()
        {
            var listClientes = service.BuscarTodos();
            return View(listClientes.ToList());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteFormViewModel obj)
        {
            service.Inserir(obj.cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var clienteBd = service.Buscar(id);
            ClienteFormViewModel clienteForm = new ClienteFormViewModel();
            clienteForm.cliente = clienteBd;
            return View(clienteForm);
        }

        [HttpPost]
        public IActionResult Editar(ClienteFormViewModel obj)
        {
            service.Atualizar(obj.cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int? id)
        {
            var cliente = service.Buscar(id.Value);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            service.Deletar(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
