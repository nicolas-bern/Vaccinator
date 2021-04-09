using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Vaccinator.Controllers
{
    public class RetardRappelController : Controller
    {
        private readonly ContexteBDD _context;

        public RetardRappelController(ContexteBDD context)
        {
            _context = context;
        }

        // GET: RetardRappel
        public async Task<IActionResult> Index()
        {
            IQueryable<Personne> listPersonnes;

            listPersonnes = from p in _context.Personnes
                            where (
                            from i in _context.Injection
                            where i.DateRappel < DateTime.Now
                            select i.Personne.Id).Contains(p.Id)
                            select p;

            return View(await listPersonnes.ToListAsync());
        }
    }
}
