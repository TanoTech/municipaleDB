using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipale.Models;

namespace Municipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly MunicipaleContext _context;

        public TipoViolazioneController(MunicipaleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<TipoViolazione> TipoViolazione = await _context.TipoViolazione.ToListAsync();
            return View(TipoViolazione);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Add(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _context.TipoViolazione.Add(tipoViolazione);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violazione = await _context.TipoViolazione.FindAsync(id);
            if (violazione == null)
            {
                return NotFound();
            }

            return View(violazione);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfermata(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violazione = await _context.TipoViolazione.FindAsync(id);
            if (violazione == null)
            {
                return NotFound();
            }

            _context.TipoViolazione.Remove(violazione);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
