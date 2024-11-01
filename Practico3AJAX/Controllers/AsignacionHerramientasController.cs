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

        // GET: AsignacionHerramientas/Create
        public IActionResult Create()
        {


            ViewData["IdUnidadHerramienta"] = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre");

            ViewData["Estado"] = new SelectList(Enum.GetValues(typeof(EstadoAsignacion)).Cast<EstadoAsignacion>().Select(e => new {
                Value = (int)e,
                Text = e.ToString()
            }), "Value", "Text");

            return View();
        }

        // POST: AsignacionHerramientas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUnidadHerramienta,IdUsuario,FechaAsignacion,FechaDevolucion,Estado")] AsignacionHerramienta asignacionHerramienta)
        {
            
            var herramientaAsignada = await _context.AsignacionHerramientas
                .AnyAsync(a => a.IdUnidadHerramienta == asignacionHerramienta.IdUnidadHerramienta && a.FechaDevolucion == null);
            if (herramientaAsignada)
            {
                ModelState.AddModelError("IdUnidadHerramienta", "Esta herramienta ya está asignada.");
            }

           
            var unidadHerramientaExiste = await _context.UnidadHerramientas.AnyAsync(uh => uh.Id == asignacionHerramienta.IdUnidadHerramienta);
            if (!unidadHerramientaExiste)
            {
                ModelState.AddModelError("IdUnidadHerramienta", "La herramienta seleccionada no existe.");
            }

            
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == asignacionHerramienta.IdUsuario);
            if (!usuarioExiste)
            {
                ModelState.AddModelError("IdUsuario", "El usuario seleccionado no existe.");
            }

            
            if (asignacionHerramienta.FechaDevolucion.HasValue && asignacionHerramienta.FechaDevolucion <= asignacionHerramienta.FechaAsignacion)
            {
                ModelState.AddModelError("FechaDevolucion", "La fecha de devolución debe ser posterior a la fecha de asignación.");
            }

            
            if (asignacionHerramienta.Estado == default(EstadoAsignacion))
            {
                ModelState.AddModelError("Estado", "El estado es obligatorio.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(asignacionHerramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdUnidadHerramienta"] = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie", asignacionHerramienta.IdUnidadHerramienta);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre", asignacionHerramienta.IdUsuario);

            ViewData["Estado"] = new SelectList(Enum.GetValues(typeof(EstadoAsignacion)).Cast<EstadoAsignacion>().Select(e => new {
                Value = (int)e,
                Text = e.ToString()
            }), "Value", "Text");

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

            ViewData["IdUnidadHerramienta"] = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie", asignacionHerramienta.IdUnidadHerramienta);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre", asignacionHerramienta.IdUsuario);

            ViewData["Estado"] = new SelectList(Enum.GetValues(typeof(EstadoAsignacion)).Cast<EstadoAsignacion>().Select(e => new {
                Value = (int)e,
                Text = e.ToString()
            }), "Value", "Text");

            return View(asignacionHerramienta);
        }

        // POST: AsignacionHerramientas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUnidadHerramienta,IdUsuario,FechaAsignacion,FechaDevolucion,Estado")] AsignacionHerramienta asignacionHerramienta)
        {
            if (id != asignacionHerramienta.Id)
            {
                return NotFound();
            }

            
            var herramientaAsignada = await _context.AsignacionHerramientas
                .AnyAsync(a => a.IdUnidadHerramienta == asignacionHerramienta.IdUnidadHerramienta && a.Id != asignacionHerramienta.Id && a.FechaDevolucion == null);
            if (herramientaAsignada)
            {
                ModelState.AddModelError("IdUnidadHerramienta", "Esta herramienta ya está asignada.");
            }

            
            if (asignacionHerramienta.FechaDevolucion.HasValue && asignacionHerramienta.FechaDevolucion <= asignacionHerramienta.FechaAsignacion)
            {
                ModelState.AddModelError("FechaDevolucion", "La fecha de devolución debe ser posterior a la fecha de asignación.");
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

            ViewData["IdUnidadHerramienta"] = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie", asignacionHerramienta.IdUnidadHerramienta);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre", asignacionHerramienta.IdUsuario);
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
