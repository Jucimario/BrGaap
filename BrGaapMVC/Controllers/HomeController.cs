using BrGaapMVC.Models;
using BrGaapMVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static BrGaapMVC.Models.DetalheUsuarioModel;

namespace BrGaapMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(UsuarioService.ListaUsuario());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            DetalheUsuarioObject detalheUsuario = UsuarioService.DetalheUsuario(id);
            if (detalheUsuario == null)
            {
                return NotFound(); 
            }
            return View(detalheUsuario);            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}