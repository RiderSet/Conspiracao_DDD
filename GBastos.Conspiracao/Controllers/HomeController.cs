using System.Diagnostics;
using GBastos.Conspiracao.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GBastos.Conspiracao.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        ///[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro/{id:lenght(3,3)}")]
        public IActionResult Error(int id)
        {
            var ModelError = new ErrorViewModel();

            if (id == 500)
            {
                ModelError.Mensagem = "Ocorreu um erro!";
                ModelError.Titulo = "Ocorreu um erro";
                ModelError.ErroCode = id;
            }
            else if (id == 404)
            {
                ModelError.Mensagem = "A página não existe!";
                ModelError.Titulo = "Página não encontrada";
                ModelError.ErroCode = id;
            }
            else if (id == 403)
            {
                ModelError.Mensagem = "Você não tem permissão para fazer isso!";
                ModelError.Titulo = "Permissão negada";
                ModelError.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                return View("Error", ModelError);
        }
    }
}
