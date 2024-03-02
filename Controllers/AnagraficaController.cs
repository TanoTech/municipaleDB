using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipale.Models;

namespace Municipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly MunicipaleContext _context;
        
        public AnagraficaController(MunicipaleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Anagrafica> anagrafica = await _context.Anagrafica.ToListAsync();
            return View(anagrafica);
        }
    }
}