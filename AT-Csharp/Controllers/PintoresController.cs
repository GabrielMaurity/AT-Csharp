using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT_Csharp.Data;
using AT_Csharp.Models;

namespace AT_Csharp.Controllers
{
    public class PintoresController : Controller
    {
        private readonly AT_CsharpContext _context;

        public PintoresController(AT_CsharpContext context)
        {
            _context = context;
        }

        // GET: Pintores
        public async Task<IActionResult> Index()
        {
              return _context.Pintores != null ? 
                          View(await _context.Pintores.ToListAsync()) :
                          Problem("Entity set 'AT_CsharpContext.Pintores'  is null.");
        }

        // GET: Pintores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pintores == null)
            {
                return NotFound();
            }

            var pintores = await _context.Pintores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pintores == null)
            {
                return NotFound();
            }

            return View(pintores);
        }

        // GET: Pintores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pintores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,anoNascimento")] Pintores pintores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pintores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pintores);
        }

        // GET: Pintores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pintores == null)
            {
                return NotFound();
            }

            var pintores = await _context.Pintores.FindAsync(id);
            if (pintores == null)
            {
                return NotFound();
            }
            return View(pintores);
        }

        // POST: Pintores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,anoNascimento")] Pintores pintores)
        {
            if (id != pintores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pintores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PintoresExists(pintores.Id))
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
            return View(pintores);
        }

        // GET: Pintores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pintores == null)
            {
                return NotFound();
            }

            var pintores = await _context.Pintores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pintores == null)
            {
                return NotFound();
            }

            return View(pintores);
        }

        // POST: Pintores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pintores == null)
            {
                return Problem("Entity set 'AT_CsharpContext.Pintores'  is null.");
            }
            var pintores = await _context.Pintores.FindAsync(id);
            if (pintores != null)
            {
                _context.Pintores.Remove(pintores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PintoresExists(int id)
        {
          return (_context.Pintores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
