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
    public class PinturasController : Controller
    {
        private readonly AT_CsharpContext _context;

        public PinturasController(AT_CsharpContext context)
        {
            _context = context;
        }

        // GET: Pinturas
        public async Task<IActionResult> Index()
        {
              return _context.Pintura != null ? 
                          View(await _context.Pintura.ToListAsync()) :
                          Problem("Entity set 'AT_CsharpContext.Pintura'  is null.");
        }

        // GET: Pinturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pintura == null)
            {
                return NotFound();
            }

            var pintura = await _context.Pintura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pintura == null)
            {
                return NotFound();
            }

            return View(pintura);
        }

        // GET: Pinturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pinturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,autor,data,valor,cores")] Pintura pintura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pintura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pintura);
        }

        // GET: Pinturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pintura == null)
            {
                return NotFound();
            }

            var pintura = await _context.Pintura.FindAsync(id);
            if (pintura == null)
            {
                return NotFound();
            }
            return View(pintura);
        }

        // POST: Pinturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,autor,data,valor")] Pintura pintura)
        {
            if (id != pintura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pintura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PinturaExists(pintura.Id))
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
            return View(pintura);
        }

        // GET: Pinturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pintura == null)
            {
                return NotFound();
            }

            var pintura = await _context.Pintura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pintura == null)
            {
                return NotFound();
            }

            return View(pintura);
        }

        // POST: Pinturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pintura == null)
            {
                return Problem("Entity set 'AT_CsharpContext.Pintura'  is null.");
            }
            var pintura = await _context.Pintura.FindAsync(id);
            if (pintura != null)
            {
                _context.Pintura.Remove(pintura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PinturaExists(int id)
        {
          return (_context.Pintura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
