using GuardianGrid.AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GuardianGrid.AdminPanel.Controllers
{
    public class AlertasController : Controller
    {
        private readonly GuardianGridContext _context;

        public AlertasController(GuardianGridContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("usuario_logado");
            if (string.IsNullOrEmpty(usuario))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Index()
        {
            var alertas = await _context.Alertas
                .OrderByDescending(a => a.CriadoEm)
                .ToListAsync();
            return View(alertas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Alerta alerta)
        {
            if (!ModelState.IsValid)
                return View(alerta);

            try
            {
                alerta.CriadoEm = DateTime.Now;
                _context.Alertas.Add(alerta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao salvar alerta: " + ex.Message);
                return View(alerta);
            }
        }
    }
}
