using GuardianGrid.AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace GuardianGrid.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly GuardianGridContext _context;

        public DashboardController(GuardianGridContext context)
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
            var estatisticas = await _context.Eventos
                .GroupBy(e => e.Regiao)
                .Select(g => new
                {
                    Regiao = g.Key,
                    Total = g.Count()
                })
                .ToListAsync();

            ViewBag.Labels = estatisticas.Select(e => e.Regiao).ToArray();
            ViewBag.Values = estatisticas.Select(e => e.Total).ToArray();

            return View();
        }

        public async Task<IActionResult> ZonasCriticas()
        {
            var diasLimite = DateTime.Now.AddDays(-7);

            var eventosRecentes = await _context.Eventos
                .Where(e => e.DataOcorrencia >= diasLimite)
                .ToListAsync();

            var zonasCriticas = eventosRecentes
                .GroupBy(e => e.Regiao)
                .Select(g => new
                {
                    Regiao = g.Key,
                    Quantidade = g.Count()
                })
                .Where(x => x.Quantidade >= 3)
                .OrderByDescending(x => x.Quantidade)
                .ToList();

            ViewBag.Zonas = zonasCriticas;

            return View();
        }
    }
}
