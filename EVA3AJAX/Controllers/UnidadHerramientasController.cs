using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVA3AJAX.Data;
using EVA3AJAX.Models;

namespace EVA3AJAX.Controllers
{
    public class UnidadHerramientasController : Controller
    {
        private readonly ProyectoDBContext _context;

        public UnidadHerramientasController(ProyectoDBContext context)
        {
            _context = context;
        }

        // GET: UnidadHerramientas
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["ActivePage"] = "UnidadHerramientas";
            var unidadHerramientas = from m in _context.UnidadHerramientas
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                unidadHerramientas = unidadHerramientas.Where(m => m.NumeroSerie.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;
            return View(await unidadHerramientas.ToListAsync());

        }

        public async Task<IActionResult> UnidadesPorHerramienta(int herramientaId)
        {
            var unidades = await _context.UnidadHerramientas.Where(u => u.HerramientaId == herramientaId).ToListAsync();
            ViewData["ActivePage"] = "UnidadHerramientas";
            return View(unidades);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, string nuevoEstado)
        {
            var unidad = await _context.UnidadHerramientas.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }

            if (nuevoEstado != "Disponible" && nuevoEstado != "En Uso" && nuevoEstado != "En Mantención")
            {
                ModelState.AddModelError("", "El estado debe ser 'Disponible', 'En Uso' o 'En Mantención'.");
                return View(unidad);
            }

            unidad.Estado = nuevoEstado;
            _context.Update(unidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: UnidadHerramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["ActivePage"] = "UnidadHerramientas";
            if (id == null || _context.UnidadHerramientas == null)
            {
                return NotFound();
            }

            var unidadHerramienta = await _context.UnidadHerramientas
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
            ViewData["ActivePage"] = "UnidadHerramientas";
            ViewBag.Estados = new SelectList(new[] { "Disponible", "En Uso", "En Mantención" });
            ViewBag.Herramientas = new SelectList(_context.Herramientas, "Id", "Modelo");
            return View();
        }

        // POST: UnidadHerramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroSerie,Estado,HerramientaId")] UnidadHerramienta unidadHerramienta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadHerramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estados = new SelectList(new[] { "Disponible", "En Uso", "En Mantención" });
            ViewBag.Herramientas = new SelectList(_context.Herramientas, "Id", "Modelo");
            return View(unidadHerramienta);
        }

        // GET: UnidadHerramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["ActivePage"] = "UnidadHerramientas";
            if (id == null || _context.UnidadHerramientas == null)
            {
                return NotFound();
            }

            var unidadHerramienta = await _context.UnidadHerramientas.FindAsync(id);
            if (unidadHerramienta == null)
            {
                return NotFound();
            }
            ViewBag.Estados = new SelectList(new[] { "Disponible", "En Uso", "En Mantención" });
            ViewBag.Herramientas = new SelectList(_context.Herramientas, "Id", "Modelo");
            return View(unidadHerramienta);
        }

        // POST: UnidadHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroSerie,Estado,HerramientaId")] UnidadHerramienta unidadHerramienta)
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
            return View(unidadHerramienta);
        }

        // GET: UnidadHerramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["ActivePage"] = "UnidadHerramientas";
            if (id == null || _context.UnidadHerramientas == null)
            {
                return NotFound();
            }

            var unidadHerramienta = await _context.UnidadHerramientas
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
            var unidadHerramienta = await _context.UnidadHerramientas.FindAsync(id);
            if (unidadHerramienta == null)
            {
                return NotFound();
            }

            // Verificar estado
            if (unidadHerramienta.Estado != "Disponible")
            {
                ModelState.AddModelError("", "No se puede eliminar la unidad porque está en uso o en mantención.");
                return View(unidadHerramienta);
            }

            _context.UnidadHerramientas.Remove(unidadHerramienta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadHerramientaExists(int id)
        {
          return (_context.UnidadHerramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
