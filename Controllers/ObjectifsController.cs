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
    public class ObjectifsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObjectifsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Objectifs
        public async Task<IActionResult> Index()
        {
              return _context.Objectif != null ? 
                          View(await _context.Objectif.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Objectif'  is null.");
        }

        // GET: Objectifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Objectif == null)
            {
                return NotFound();
            }

            var objectif = await _context.Objectif
                .FirstOrDefaultAsync(m => m.ObjectifId == id);
            if (objectif == null)
            {
                return NotFound();
            }

            return View(objectif);
        }

        // GET: Objectifs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objectifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectifId,Nom")] Objectif objectif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objectif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objectif);
        }

        // GET: Objectifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Objectif == null)
            {
                return NotFound();
            }

            var objectif = await _context.Objectif.FindAsync(id);
            if (objectif == null)
            {
                return NotFound();
            }
            return View(objectif);
        }

        // POST: Objectifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectifId,Nom")] Objectif objectif)
        {
            if (id != objectif.ObjectifId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objectif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectifExists(objectif.ObjectifId))
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
            return View(objectif);
        }

        // GET: Objectifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Objectif == null)
            {
                return NotFound();
            }

            var objectif = await _context.Objectif
                .FirstOrDefaultAsync(m => m.ObjectifId == id);
            if (objectif == null)
            {
                return NotFound();
            }

            return View(objectif);
        }

        // POST: Objectifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Objectif == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Objectif'  is null.");
            }
            var objectif = await _context.Objectif.FindAsync(id);
            if (objectif != null)
            {
                _context.Objectif.Remove(objectif);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectifExists(int id)
        {
          return (_context.Objectif?.Any(e => e.ObjectifId == id)).GetValueOrDefault();
        }
    }
}
