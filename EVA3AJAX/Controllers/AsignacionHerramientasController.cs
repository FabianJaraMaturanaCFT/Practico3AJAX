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
    public class AsignacionHerramientasController : Controller
    {
        private readonly ProyectoDBContext _context;

        public AsignacionHerramientasController(ProyectoDBContext context)
        {
            _context = context;
        }

        // GET: AsignacionHerramientas
        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = "AsignacionHerramientas"; 
            return _context.AsignacionHerramientas != null ?
                View(await _context.AsignacionHerramientas.ToListAsync()) :
                Problem("Entity set 'ProyectoDBContext.AsignacionHerramientas' is null.");
        }


        // GET: AsignacionHerramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["ActivePage"] = "AsignacionHerramientas";
            if (id == null || _context.AsignacionHerramientas == null)
            {
                return NotFound();
            }

            var asignacionHerramienta = await _context.AsignacionHerramientas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacionHerramienta == null)
            {
                return NotFound();
            }

            return View(asignacionHerramienta);
        }

        // GET: AsignacionHerramientas/Create
        public IActionResult Create()
        {
            ViewData["ActivePage"] = "AsignacionHerramientas";
            ViewBag.UnidadHerramientas = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie");
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: AsignacionHerramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnidadHerramientaId,UsuarioId,FechaAsignacion")] AsignacionHerramienta asignacionHerramienta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionHerramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.UnidadHerramientas = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie");
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View(asignacionHerramienta);
        }

        // GET: AsignacionHerramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["ActivePage"] = "AsignacionHerramientas";
            if (id == null || _context.AsignacionHerramientas == null)
            {
                return NotFound();
            }

            var asignacionHerramienta = await _context.AsignacionHerramientas.FindAsync(id);
            if (asignacionHerramienta == null)
            {
                return NotFound();
            }
            ViewBag.UnidadHerramientas = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie");
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View(asignacionHerramienta);
        }

        // POST: AsignacionHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnidadHerramientaId,UsuarioId,FechaAsignacion")] AsignacionHerramienta asignacionHerramienta)
        {
            if (id != asignacionHerramienta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionHerramienta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionHerramientaExists(asignacionHerramienta.Id))
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
            return View(asignacionHerramienta);
        }

        // GET: AsignacionHerramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["ActivePage"] = "AsignacionHerramientas";
            if (id == null || _context.AsignacionHerramientas == null)
            {
                return NotFound();
            }

            var asignacionHerramienta = await _context.AsignacionHerramientas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacionHerramienta == null)
            {
                return NotFound();
            }

            return View(asignacionHerramienta);
        }

        // POST: AsignacionHerramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AsignacionHerramientas == null)
            {
                return Problem("Entity set 'ProyectoDBContext.AsignacionHerramientas'  is null.");
            }
            var asignacionHerramienta = await _context.AsignacionHerramientas.FindAsync(id);
            if (asignacionHerramienta != null)
            {
                _context.AsignacionHerramientas.Remove(asignacionHerramienta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionHerramientaExists(int id)
        {
          return (_context.AsignacionHerramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
