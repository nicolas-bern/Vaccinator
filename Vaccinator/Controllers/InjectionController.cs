using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Vaccinator.Controllers
{
    public class InjectionController : Controller
    {
        private readonly ContexteBDD _context;

        public InjectionController(ContexteBDD context)
        {
            _context = context;
        }

        // GET: Injection
        public async Task<IActionResult> Index()
        {
            return View(await _context.Injection.ToListAsync());
        }

        // GET: Injection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // GET: Injection/Create
        public IActionResult Create()
        {
            ViewBag.ListPersonnes = _context.Personnes.Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id.ToString()}).ToList();
            ViewBag.ListVaccins = _context.Vaccin.Select(v => new SelectListItem { Text = "Vaccin pour " + v.Type + " du laboratoire " + v.Marque, Value = v.Id.ToString() }).ToList();
            return View();
        }

        // POST: Injection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection formCollection)
        {
            Injection injection = new Injection();

            injection.Personne = _context.Personnes.Find(int.Parse(formCollection["Personne"]));
            injection.Vaccin = _context.Vaccin.Find(int.Parse(formCollection["Vaccin"]));
            injection.Lot = int.Parse(formCollection["Lot"]);
            injection.DateAdministration = DateTime.Parse(formCollection["DateAdministration"]);
            injection.DateRappel = DateTime.Parse(formCollection["DateRappel"]);

            if (ModelState.IsValid)
            {
                _context.Add(injection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(injection);
        }

        // GET: Injection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injection.FindAsync(id);
            if (injection == null)
            {
                return NotFound();
            }
            return View(injection);
        }

        // POST: Injection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lot,DateAdministration")] Injection injection)
        {
            if (id != injection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjectionExists(injection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(injection);
        }

        // GET: Injection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // POST: Injection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injection = await _context.Injection.FindAsync(id);
            _context.Injection.Remove(injection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjectionExists(int id)
        {
            return _context.Injection.Any(e => e.Id == id);
        }
    }
}
