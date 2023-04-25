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
        [HttpGet]
        public IActionResult Index()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            try
            {
                if (_loginService.Login(username, password))
                    return RedirectToAction("Index","Perfils", new { UserName = username });

                TempData["Warn"] = "Insira informações válidas!";
                return View();

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult CriarUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarUsuario(Usuario usuario)
        {
            if (_loginService.Criar(usuario))
                return RedirectToAction(nameof(Index));

            TempData["Warn"] = "A campos inválidos!";
            return View();
        }
        [HttpGet]
        public IActionResult EsqueciSenha()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EsqueciSenha(string email)
        {
            if (_loginService.EsqueciSenha(email))
            {
                TempData["Info"] = "Seu Codigo foi enviado com sucesso!";
                return RedirectToAction(nameof(VrfCodigo));
            }
            return View(EsqueciSenha());
        }
        [HttpGet]
        public IActionResult VrfCodigo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VrfCodigo(string CodigoRecup)
        {
            try
            {
                var username = _loginService.VrfCodigo(CodigoRecup);
                return RedirectToAction("MudarSenha", new { UserName = username });
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult MudarSenha(string username)
        {
            ViewData["username"] = username;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MudarSenha(string senhaPri, string senhaSeg, string username)
        {

            if (senhaPri == senhaSeg && senhaPri != null)
            {
                _loginService.MudarSenha(senhaPri, username);
                TempData["Info"] = "Sua Senha foi alterada com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Info"] = "As senhas precisam ser parecidas enão podem ser vazias!";
                return View();
            }
        }
    }
}
