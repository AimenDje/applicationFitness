using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuiviFitness.Models;

namespace SuiviFitness.Controllers
{
    public class ExercicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExercicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Exercices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Exercices.Include(e => e.Objectif);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Exercices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exercices == null)
            {
                return NotFound();
            }

            var exercice = await _context.Exercices
                .Include(e => e.Objectif)
                .FirstOrDefaultAsync(m => m.IDExercice == id);
            if (exercice == null)
            {
                return NotFound();
            }

            return View(exercice);
        }

        // GET: Exercices/Create
        public IActionResult Create()
        {
            ViewData["ObjectifId"] = new SelectList(_context.Set<Objectif>(), "ObjectifId", "Nom");
            return View();
        }

        // POST: Exercices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDExercice,NomExercice,Description,Photo,ObjectifId")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjectifId"] = new SelectList(_context.Set<Objectif>(), "ObjectifId", "Nom", exercice.ObjectifId);
            return View(exercice);
        }

        // GET: Exercices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exercices == null)
            {
                return NotFound();
            }

            var exercice = await _context.Exercices.FindAsync(id);
            if (exercice == null)
            {
                return NotFound();
            }
            ViewData["ObjectifId"] = new SelectList(_context.Set<Objectif>(), "ObjectifId", "Nom", exercice.ObjectifId);
            return View(exercice);
        }

        // POST: Exercices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDExercice,NomExercice,Description,Photo,ObjectifId")] Exercice exercice)
        {
            if (id != exercice.IDExercice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciceExists(exercice.IDExercice))
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
            ViewData["ObjectifId"] = new SelectList(_context.Set<Objectif>(), "ObjectifId", "Nom", exercice.ObjectifId);
            return View(exercice);
        }

        // GET: Exercices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exercices == null)
            {
                return NotFound();
            }

            var exercice = await _context.Exercices
                .Include(e => e.Objectif)
                .FirstOrDefaultAsync(m => m.IDExercice == id);
            if (exercice == null)
            {
                return NotFound();
            }

            return View(exercice);
        }

        // POST: Exercices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exercices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.exercices'  is null.");
            }
            var exercice = await _context.Exercices.FindAsync(id);
            if (exercice != null)
            {
                _context.Exercices.Remove(exercice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciceExists(int id)
        {
          return (_context.Exercices?.Any(e => e.IDExercice == id)).GetValueOrDefault();
        }

        public async Task<ActionResult> GetExercicesByObjectif(int id)
        {
            // Récupère la liste des catégories depuis la base de données (peut être une erreur, devrait probablement récupérer les livres par catégorie)
            var liste = await _context.Objectif.ToListAsync();
            return View("ExercicesByObj", liste);
        }

        // Action pour rechercher des livres par catégorie
        public async Task<ActionResult> Search2(int id)
        {
            // Récupère la liste des livres appartenant à une catégorie spécifique
            var liste = await _context.Exercices.Where(p => p.ObjectifId == id).ToListAsync();
            return View("ExercicesBySearch", liste);
        }

        // Action pour rechercher des livres par nom de livre ou de catégorie
        [HttpPost]
        public async Task<ActionResult> Search(string searchName)
        {
            // Recherche des livres en fonction du nom du livre ou de la catégorie
            var result = await _context.Exercices.Where(p => p.NomExercice.Contains(searchName) || p.Objectif.Nom.Contains(searchName)).ToListAsync();
            return View("ExercicesBySearch", result);
        }

    }
}
