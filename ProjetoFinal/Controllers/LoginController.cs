using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult List()
        {
            return View();
        }
        
        public ActionResult Login(string email, string password)
        {
            var user = new Usuario { Email = "usuario@example.com", Senha = "senha" }; // informações de usuário "hardcoded" (não é recomendado na prática)

            if (email == user.Email && password == user.Senha)
            {
                // informações de login válidas, criar sessão
               // Session["user"] = user.Email;

                return RedirectToAction("Index", "Home"); // redirecionar para página inicial do site
            }

            // informações de login inválidas
            ViewBag.ErrorMessage = "Endereço de email ou senha incorretos.";
            return View();
        }
    }
}