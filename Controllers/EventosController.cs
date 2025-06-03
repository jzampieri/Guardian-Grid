using System.Globalization;
using CsvHelper;
using System.IO;
using GuardianGrid.AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

public class EventosController : Controller
{
    private readonly GuardianGridContext _context;

    public EventosController(GuardianGridContext context)
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
        var eventos = await _context.Eventos
            .OrderByDescending(e => e.DataOcorrencia)
            .ToListAsync();

        return View(eventos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Evento evento)
    {
        if (!ModelState.IsValid)
            return View(evento);

        try
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Erro ao salvar o evento: " + ex.Message);
            return View(evento);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ExportarCSV()
    {
        var eventos = await _context.Eventos
            .OrderByDescending(e => e.DataOcorrencia)
            .ToListAsync();

        using var memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream, leaveOpen: true))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(eventos);
        }

        memoryStream.Position = 0;

        var nomeArquivo = $"relatorio_eventos_{DateTime.Now:yyyyMMdd_HHmm}.csv";
        return File(memoryStream.ToArray(), "text/csv", nomeArquivo);
    }
}
