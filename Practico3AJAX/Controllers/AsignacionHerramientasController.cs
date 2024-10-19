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
    public class AsignacionHerramientasController : Controller
    {
        private readonly ProyectoDBContext _context;

        public AsignacionHerramientasController(ProyectoDBContext context)
        {
            _context = context;
        }

        private async Task ReducirInventarioHerramienta(int unidadHerramientaId)
        {
            // Obtener la unidad de herramienta
            var unidadHerramienta = await _context.UnidadHerramientas
                .Include(u => u.Herramienta) // Incluir la herramienta relacionada
                .FirstOrDefaultAsync(u => u.Id == unidadHerramientaId);

            if (unidadHerramienta != null)
            {
                // Aquí asumimos que el campo Estado indica disponibilidad, actualizamos a "En uso"
                unidadHerramienta.Estado = "En uso"; // Actualiza el estado de la unidad de herramienta

                // Si tienes una cantidad disponible en la clase Herramienta, restar 1
                // unidadHerramienta.Herramienta.CantidadDisponible--;

                _context.Update(unidadHerramienta);
                await _context.SaveChangesAsync();
            }
        }

        // GET: AsignacionHerramientas
        public async Task<IActionResult> Index()
        {
            var proyectoDBContext = _context.AsignacionHerramientas.Include(a => a.UnidadHerramienta).Include(a => a.Usuario);
            return View(await proyectoDBContext.ToListAsync());
        }

        // GET: AsignacionHerramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AsignacionHerramientas == null)
            {
                return NotFound();
            }

            var asignacionHerramienta = await _context.AsignacionHerramientas
                .Include(a => a.UnidadHerramienta)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacionHerramienta == null)
            {
                return NotFound();
            }

            return View(asignacionHerramienta);
        }

        public IActionResult Create()
        {
            ViewData["UnidadHerramientaId"] = new SelectList(_context.UnidadHerramientas, "Id", "Estado");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // GET: AsignacionHerramientas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnidadHerramientaId,UsuarioId,FechaAsignacion,FechaDevolucion")] AsignacionHerramienta asignacionHerramienta)
        {
            // Verificar si el usuario ya tiene 3 herramientas asignadas
            int herramientasAsignadas = _context.AsignacionHerramientas
                .Count(a => a.UsuarioId == asignacionHerramienta.UsuarioId && a.FechaDevolucion == null);

            if (herramientasAsignadas >= 3)
            {
                // Error: El usuario ya tiene 3 herramientas asignadas sin devolver
                ModelState.AddModelError("", "Un usuario no puede tener más de 3 herramientas asignadas.");
                ViewData["UnidadHerramientaId"] = new SelectList(_context.UnidadHerramientas, "Id", "Estado", asignacionHerramienta.UnidadHerramientaId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacionHerramienta.UsuarioId);
                return View(asignacionHerramienta);
            }

            if (ModelState.IsValid)
            {
                // Aquí llamamos a la función que reduce el stock de la herramienta
                await ReducirInventarioHerramienta(asignacionHerramienta.UnidadHerramientaId);

                // Guardar la asignación si pasa las validaciones
                _context.Add(asignacionHerramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UnidadHerramientaId"] = new SelectList(_context.UnidadHerramientas, "Id", "Estado", asignacionHerramienta.UnidadHerramientaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacionHerramienta.UsuarioId);
            return View(asignacionHerramienta);
        }

        // GET: AsignacionHerramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AsignacionHerramientas == null)
            {
                return NotFound();
            }

            var asignacionHerramienta = await _context.AsignacionHerramientas.FindAsync(id);
            if (asignacionHerramienta == null)
            {
                return NotFound();
            }
            ViewData["UnidadHerramientaId"] = new SelectList(_context.UnidadHerramientas, "Id", "Estado", asignacionHerramienta.UnidadHerramientaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacionHerramienta.UsuarioId);
            return View(asignacionHerramienta);
        }

        // POST: AsignacionHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnidadHerramientaId,UsuarioId,FechaAsignacion,FechaDevolucion")] AsignacionHerramienta asignacionHerramienta)
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
            ViewData["UnidadHerramientaId"] = new SelectList(_context.UnidadHerramientas, "Id", "Estado", asignacionHerramienta.UnidadHerramientaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacionHerramienta.UsuarioId);
            return View(asignacionHerramienta);
        }

        // GET: AsignacionHerramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AsignacionHerramientas == null)
            {
                return NotFound();
            }

            var asignacionHerramienta = await _context.AsignacionHerramientas
                .Include(a => a.UnidadHerramienta)
                .Include(a => a.Usuario)
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
