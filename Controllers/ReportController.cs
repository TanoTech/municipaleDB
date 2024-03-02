using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipale.Models;


namespace Municipale.Controllers
{
    public class ReportController : Controller
    {
        private readonly MunicipaleContext _context;

        public ReportController(MunicipaleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reportTotali = await Report();
            var violazioni400 = await GetMaggiori400Euro();
            var punti10 = await GetPunti10();

            var model = new List<List<Report>>
    {
        reportTotali,
        violazioni400,
        punti10
    };
            return View(model);
        }

        public async Task<IActionResult> Violazioni()
        {
            var violazioni400 = await GetMaggiori400Euro();
            return View(violazioni400);
        }

        public async Task<IActionResult> Punti()
        {
            var punti10 = await GetPunti10();
            return View(punti10);
        }

        private async Task<List<Report>> Report()
        {
            var reports = new List<Report>();

            var verbaliPerTrasgressore = await _context.Verbali
                .GroupBy(v => new { v.IDAnagrafe })
                .Select(g => new
                {
                    IDAnagrafe = g.Key.IDAnagrafe,
                    TotaleVerbali = g.Count(),
                    TotalePuntiDecurtati = g.Sum(v => v.DecurtamentoPunti)
                })
                .ToListAsync();

            foreach (var item in verbaliPerTrasgressore)
            {
                var anagrafica = await _context.Anagrafica.FindAsync(item.IDAnagrafe);
                var trasgressore = anagrafica != null ? $"{anagrafica.Cognome} {anagrafica.Nome}" : "Anagrafica non trovata";

                var report = new Report
                {
                    Trasgressore = trasgressore,
                    TotaleVerbali = item.TotaleVerbali,
                    TotalePuntiDecurtati = item.TotalePuntiDecurtati
                    
                };
                reports.Add(report);
            }
            return reports;
        }

        private async Task<List<Report>> GetMaggiori400Euro()
        {
            var reports = new List<Report>();

            var verbaliPerTrasgressore = await _context.Verbali
                .Where(v => v.Importo > 400)
                .ToListAsync();

            foreach (var verbale in verbaliPerTrasgressore)
            {
                var trasgressoreName = await GetTrasgressoreName(verbale.IDAnagrafe);

                var report = new Report
                {
                    Trasgressore = trasgressoreName,
                    DataViolazione = verbale.DataViolazione,
                    IndirizzoViolazione = verbale.IndirizzoViolazione,
                    Importo = verbale.Importo,
                    TotalePuntiDecurtati = verbale.DecurtamentoPunti
                };
                reports.Add(report);
            }

            return reports;
        }

        private async Task<List<Report>> GetPunti10()
        {
            var reports = new List<Report>();

            var verbaliPerTrasgressore = await _context.Verbali
                .Where(v => v.DecurtamentoPunti > 10)
                .ToListAsync();

            foreach (var verbale in verbaliPerTrasgressore)
            {
                var trasgressoreName = await GetTrasgressoreName(verbale.IDAnagrafe);

                var report = new Report
                {
                    Trasgressore = trasgressoreName,
                    DataViolazione = verbale.DataViolazione,
                    IndirizzoViolazione = verbale.IndirizzoViolazione,
                    Importo = verbale.Importo,
                    TotalePuntiDecurtati = verbale.DecurtamentoPunti
                };
                reports.Add(report);
            }

            return reports;
        }


        private async Task<string> GetTrasgressoreName(int IDAnagrafe)
        {
            var anagrafica = await _context.Anagrafica.FindAsync(IDAnagrafe);
            return anagrafica != null ? $"{anagrafica.Cognome} {anagrafica.Nome}" : "Anagrafica non trovata";
        }
    }
}
