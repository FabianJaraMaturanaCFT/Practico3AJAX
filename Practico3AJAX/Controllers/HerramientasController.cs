using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practico3AJAX.Data;
using Practico3AJAX.Models;

namespace Practico3AJAX.Controllers
{
    public class HerramientasController : Controller
    {
        private readonly ProyectoDBContext _context;

        public HerramientasController(ProyectoDBContext context)
        {
            _context = context;
        }

        // GET: Herramientas
        public async Task<IActionResult> Index()
        {
              return _context.Herramientas != null ? 
                          View(await _context.Herramientas.ToListAsync()) :
                          Problem("Entity set 'ProyectoDBContext.Herramientas'  is null.");
        }

        // GET: Herramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herramienta == null)
            {
                return NotFound();
            }

            return View(herramienta);
        }

        // GET: Herramientas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,CantidadTotal,Disponibles")] Herramienta herramienta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(herramienta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al crear la herramienta: {ex.Message}");
            }

            return View(herramienta);
        }

        // GET: Herramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta == null)
            {
                return NotFound();
            }
            return View(herramienta);
        }

        // POST: Herramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Marca,CantidadTotal,Disponibles")] Herramienta herramienta)
        {
            if (id != herramienta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herramienta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerramientaExists(herramienta.Id))
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
            return View(herramienta);
        }

        // GET: Herramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herramienta == null)
            {
                return NotFound();
            }

            return View(herramienta);
        }

        // POST: Herramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Herramientas == null)
            {
                return Problem("Entity set 'ProyectoDBContext.Herramientas'  is null.");
            }
            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta != null)
            {
                _context.Herramientas.Remove(herramienta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerramientaExists(int id)
        {
          return (_context.Herramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
