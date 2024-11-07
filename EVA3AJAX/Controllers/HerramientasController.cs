using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVA3AJAX.Data;
using EVA3AJAX.Models;

namespace EVA3AJAX.Controllers
{
    public class HerramientasController : Controller
    {
        private readonly ProyectoDBContext _context;

        public HerramientasController(ProyectoDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["ActivePage"] = "Herramientas";
            var herramientas = from h in _context.Herramientas
                               select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                herramientas = herramientas.Where(h => h.Modelo.Contains(searchString));
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_HerramientasList", await herramientas.ToListAsync());
            }

            ViewData["CurrentFilter"] = searchString;
            return View(await herramientas.ToListAsync());
        }


        // GET: Herramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["ActivePage"] = "Herramientas";
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
            ViewData["ActivePage"] = "Herramientas";
            ViewBag.Marcas = new SelectList(_context.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: Herramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,IdMarca,CantidadTotal,Disponibles")] Herramienta herramienta)
        {
            if (herramienta.Disponibles > herramienta.CantidadTotal)
            {
                ModelState.AddModelError("Disponibles", "El valor de 'Disponibles' no puede ser mayor que 'CantidadTotal'.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(herramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Marcas = new SelectList(_context.Marcas, "Id", "Nombre");
            return View(herramienta);
        }

        // GET: Herramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["ActivePage"] = "Herramientas";
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta == null)
            {
                return NotFound();
            }
            ViewBag.Marcas = new SelectList(_context.Marcas, "Id", "Nombre");
            return View(herramienta);
        }

        // POST: Herramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,IdMarca,CantidadTotal,Disponibles")] Herramienta herramienta)
        {
            if (id != herramienta.Id)
            {
                return NotFound();
            }

            if (herramienta.Disponibles > herramienta.CantidadTotal)
            {
                ModelState.AddModelError("Disponibles", "El valor de 'Disponibles' no puede ser mayor que 'CantidadTotal'.");
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
            ViewData["ActivePage"] = "Herramientas";
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
            var herramienta = await _context.Herramientas.FirstOrDefaultAsync(h => h.Id == id);
            if (herramienta == null)
            {
                return NotFound();
            }

            
            var unidadHerramientas = await _context.UnidadHerramientas.Where(u => u.HerramientaId == herramienta.Id).ToListAsync();
            if (unidadHerramientas.Any())
            {
                ModelState.AddModelError("", "No se puede eliminar la herramienta porque tiene unidades asociadas.");
                return View(herramienta);
            }

            _context.Herramientas.Remove(herramienta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool HerramientaExists(int id)
        {
          return (_context.Herramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
