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
            var usuario = await _context.Usuarios.FindAsync(asignacionHerramienta.UsuarioId);
            var unidad = await _context.UnidadHerramientas.FindAsync(asignacionHerramienta.UnidadHerramientaId);

            if (unidad.Estado != "Disponible")
            {
                ModelState.AddModelError("", "La herramienta debe estar disponible para asignarse.");
            }

            
            var herramientasEnUso = await usuario.HerramientasEnUso(_context);
            if (herramientasEnUso >= 3)
            {
                ModelState.AddModelError("", "Un usuario no puede tener más de 3 herramientas asignadas.");
            }

            if (ModelState.IsValid)
            {
                // Asignación de la herramienta
                _context.Add(asignacionHerramienta);

                // Actualizar el estado de la unidad de herramienta a "En Uso"
                unidad.Estado = "En Uso";
                _context.Update(unidad); // Actualizar el estado de la unidad en la base de datos

                // Guardar los cambios en la base de datos
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

            var unidad = await _context.UnidadHerramientas
                .FirstOrDefaultAsync(u => u.Id == asignacionHerramienta.UnidadHerramientaId);

            
            if (unidad != null && (unidad.Estado == "En Uso" || unidad.Estado == "En Mantención"))
            {
                TempData["ErrorMessage"] = "No se puede eliminar esta asignación porque la herramienta está en uso o en mantención.";
                return RedirectToAction(nameof(Index));
            }

            return View(asignacionHerramienta);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolver(int id)
        {
            
            var asignacion = await _context.AsignacionHerramientas.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }

            
            var unidad = await _context.UnidadHerramientas.FindAsync(asignacion.UnidadHerramientaId);
            if (unidad != null)
            {
                
                unidad.Estado = "Disponible";
                _context.Update(unidad);
            }

            
            _context.AsignacionHerramientas.Remove(asignacion);

            
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "La herramienta ha sido devuelta exitosamente.";

            
            return RedirectToAction(nameof(Index));
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
