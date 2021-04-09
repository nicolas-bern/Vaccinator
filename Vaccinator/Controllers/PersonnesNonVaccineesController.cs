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
    public class PersonnesNonVaccineesController : Controller
    {
        private readonly ContexteBDD _context;

        public PersonnesNonVaccineesController(ContexteBDD context)
        {
            _context = context;
        }

        // GET: PersonnesNonVaccinees
        public async Task<IActionResult> Index(String VaccinSelect)
        {
            ViewBag.ListVaccins = _context.Vaccin.Select(v => new SelectListItem { Text = v.Type, Value = v.Type }).ToList();

            IQueryable<Personne> listPersonnes;

            listPersonnes = from p in _context.Personnes where !(
                            from i in _context.Injection where (
                            from v in _context.Vaccin where v.Type.Contains(VaccinSelect) select v.Type).Contains(i.Vaccin.Type)
                            select i.Personne.Id).Contains(p.Id) select p;

            return View(await listPersonnes.ToListAsync());
        }

        
    }
}
