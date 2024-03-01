using Microsoft.AspNetCore.Mvc;
using Municipale.Models;
using Municipale.ViewModels;

namespace Municipale.Controllers
{
    public class HomeController : Controller
    {
        private readonly MunicipaleContext _context;

        public HomeController(MunicipaleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new Home
            {
                Anagrafiche = _context.Anagrafica.ToList(),
                Agenti = _context.Agenti.ToList(),
                TipiViolazione = _context.TipoViolazione.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Anagrafica.Add(anagrafica);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Details(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Verbali.Add(verbale);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
    }
}