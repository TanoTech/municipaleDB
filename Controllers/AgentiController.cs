using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipale.Models;

namespace Municipale.Controllers
{
    public class AgentiController : Controller
    {
        private readonly MunicipaleContext _context;

        public AgentiController(MunicipaleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Agente> agenti = await _context.Agenti.ToListAsync();
            return View(agenti);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Add(Agente agente)
        {
            if (ModelState.IsValid)
            {
                _context.Agenti.Add(agente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
