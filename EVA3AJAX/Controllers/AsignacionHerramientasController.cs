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

            if (asignacionHerramienta.FechaAsignacion > DateTime.Now)
            {
                ModelState.AddModelError("FechaAsignacion", "La fecha de asignación no puede ser en el futuro.");
            }

            if (ModelState.IsValid)
            {
                asignacionHerramienta.FechaAsignacion = DateTime.Now;

                unidad.Estado = "En Uso";
                _context.Update(unidad);

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

            var unidadHerramienta = _context.UnidadHerramientas
                .FirstOrDefault(u => u.Id == asignacionHerramienta.UnidadHerramientaId);

            
            ViewBag.SelectedUnidadHerramienta = unidadHerramienta?.NumeroSerie;

            ViewBag.UnidadHerramientas = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie");
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View(asignacionHerramienta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnidadHerramientaId,UsuarioId,FechaRetorno")] AsignacionHerramienta modeloEditado)
        {
            var asignacionHerramienta = await _context.AsignacionHerramientas.FindAsync(id);

            if (asignacionHerramienta == null)
            {
                return NotFound();
            }
            if (modeloEditado.FechaRetorno < asignacionHerramienta.FechaAsignacion)
            {
                ModelState.AddModelError("FechaRetorno", "La Fecha de Retorno no puede ser antes de la Fecha de Asignación.");

                ViewBag.SelectedUnidadHerramienta = asignacionHerramienta.UnidadHerramientaId;
                ViewBag.SelectedUsuario = asignacionHerramienta.UsuarioId;
                ViewBag.UnidadHerramientas = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie", asignacionHerramienta.UnidadHerramientaId);
                ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", asignacionHerramienta.UsuarioId);

                return View(modeloEditado);
            }

            if (ModelState.IsValid)
            {
                asignacionHerramienta.UsuarioId = modeloEditado.UsuarioId;
                asignacionHerramienta.FechaRetorno = modeloEditado.FechaRetorno;

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

            
            ViewBag.UnidadHerramientas = new SelectList(_context.UnidadHerramientas, "Id", "NumeroSerie", modeloEditado.UnidadHerramientaId);
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", modeloEditado.UsuarioId);

            return View(modeloEditado);
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AsignacionHerramientas == null)
            {
                return Problem("Entity set 'ProyectoDBContext.AsignacionHerramientas' is null.");
            }
            var asignacionHerramienta = await _context.AsignacionHerramientas.FindAsync(id);
            if (asignacionHerramienta != null)
            {
                _context.AsignacionHerramientas.Remove(asignacionHerramienta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
                asignacion.FechaRetorno = DateTime.Now; 

                unidad.Estado = "Disponible";
                _context.Update(unidad);

                _context.AsignacionHerramientas.Remove(asignacion);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "La herramienta ha sido devuelta exitosamente.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> VerificarDisponibilidad(int unidadHerramientaId)
        {
            var unidad = await _context.UnidadHerramientas
                .FirstOrDefaultAsync(u => u.Id == unidadHerramientaId);

            if (unidad == null)
            {
                return Json(new { success = false, message = "Unidad de herramienta no encontrada." });
            }

            if (unidad.Estado == "Disponible")
            {
                return Json(new { success = true, message = "La herramienta está disponible." });
            }
            else
            {
                return Json(new { success = false, message = "La herramienta no está disponible." });
            }
        }

        private bool AsignacionHerramientaExists(int id)
        {
            return (_context.AsignacionHerramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

