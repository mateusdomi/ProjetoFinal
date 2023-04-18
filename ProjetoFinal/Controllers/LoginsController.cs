using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Infraestrutura;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Controllers
{
    

    public class LoginsController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginsController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarUsuario(Usuario usuario)
        {
            _loginService.Criar(usuario);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EsqueciSenha()
        {
            return View();
        }
    }
}
