using Microsoft.EntityFrameworkCore;
using Practico3AJAX.Models;

namespace Practico3AJAX.Data
{
    public class ProyectoDBContext : DbContext
    {
        public ProyectoDBContext(DbContextOptions<ProyectoDBContext> options) : base(options)
        {
        }

        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<UnidadHerramienta> UnidadHerramientas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AsignacionHerramienta> AsignacionHerramientas { get; set; }
        public DbSet<MantenimientoHerramienta> MantenimientoHerramientas { get; set; }

    }
}
