﻿using System;
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
    public class UnidadHerramientasController : Controller
    {
        private readonly ProyectoDBContext _context;

        public UnidadHerramientasController(ProyectoDBContext context)
        {
            _context = context;
        }

        // GET: UnidadHerramientas
        public async Task<IActionResult> Index()
        {
            var proyectoDBContext = _context.UnidadHerramientas.Include(u => u.Herramienta);
            return View(await proyectoDBContext.ToListAsync());
        }

        // GET: UnidadHerramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnidadHerramientas == null)
            {
                return NotFound();
            }

            var unidadHerramienta = await _context.UnidadHerramientas
                .Include(u => u.Herramienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadHerramienta == null)
            {
                return NotFound();
            }

            return View(unidadHerramienta);
        }

        // GET: UnidadHerramientas/Create
        public IActionResult Create()
        {
            ViewData["IdModelo"] = new SelectList(_context.Herramientas, "Id", "Modelo");
            return View();
        }

        // POST: UnidadHerramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroSerie,Estado,IdModelo,FechaIngreso,FechaRetornoBodega,FechaMantencion")] UnidadHerramienta unidadHerramienta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadHerramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdModelo"] = new SelectList(_context.Herramientas, "Id", "Modelo", unidadHerramienta.IdModelo);
            return View(unidadHerramienta);
        }

        // GET: UnidadHerramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnidadHerramientas == null)
            {
                return NotFound();
            }

            var unidadHerramienta = await _context.UnidadHerramientas.FindAsync(id);
            if (unidadHerramienta == null)
            {
                return NotFound();
            }
            ViewData["IdModelo"] = new SelectList(_context.Herramientas, "Id", "Modelo", unidadHerramienta.IdModelo);
            return View(unidadHerramienta);
        }

        // POST: UnidadHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroSerie,Estado,IdModelo,FechaIngreso,FechaRetornoBodega,FechaMantencion")] UnidadHerramienta unidadHerramienta)
        {
            if (id != unidadHerramienta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadHerramienta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadHerramientaExists(unidadHerramienta.Id))
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
            ViewData["IdModelo"] = new SelectList(_context.Herramientas, "Id", "Modelo", unidadHerramienta.IdModelo);
            return View(unidadHerramienta);
        }

        // GET: UnidadHerramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnidadHerramientas == null)
            {
                return NotFound();
            }

            var unidadHerramienta = await _context.UnidadHerramientas
                .Include(u => u.Herramienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadHerramienta == null)
            {
                return NotFound();
            }

            return View(unidadHerramienta);
        }

        // POST: UnidadHerramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnidadHerramientas == null)
            {
                return Problem("Entity set 'ProyectoDBContext.UnidadHerramientas'  is null.");
            }
            var unidadHerramienta = await _context.UnidadHerramientas.FindAsync(id);
            if (unidadHerramienta != null)
            {
                _context.UnidadHerramientas.Remove(unidadHerramienta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadHerramientaExists(int id)
        {
          return (_context.UnidadHerramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
