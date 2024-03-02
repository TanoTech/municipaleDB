using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipale.Models;

namespace Municipale.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly MunicipaleContext _context;
        public VerbaliController(MunicipaleContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Verbale> Verbale = await _context.Verbali.ToListAsync();
            return View(Verbale);
        }
    }
}