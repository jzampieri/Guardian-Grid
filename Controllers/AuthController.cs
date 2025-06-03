using GuardianGrid.AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuardianGrid.AdminPanel.Controllers
{
    public class AuthController : Controller
    {
        private const string UsuarioPadrao = "admin";
        private const string SenhaPadrao = "123456";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Usuario == UsuarioPadrao && model.Senha == SenhaPadrao)
            {
                HttpContext.Session.SetString("usuario_logado", model.Usuario);
                return RedirectToAction("Index", "Eventos");
            }

            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
