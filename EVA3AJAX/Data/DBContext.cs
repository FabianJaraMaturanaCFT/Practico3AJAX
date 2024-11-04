using Microsoft.EntityFrameworkCore;
using EVA3AJAX.Models;

namespace EVA3AJAX.Data
{
    public class ProyectoDBContext : DbContext
    {
        public ProyectoDBContext(DbContextOptions<ProyectoDBContext> options) : base(options)
        {
        }

        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<UnidadHerramienta> UnidadHerramientas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AsignacionHerramienta> AsignacionHerramientas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 1,
                Nombre = "Makita"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 2,
                Nombre = "Bosch"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 3,
                Nombre = "DeWalt"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 4,
                Nombre = "Black & Decker"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 5,
                Nombre = "Stanley"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 6,
                Nombre = "Milwaukee"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 7,
                Nombre = "Hitachi"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 8,
                Nombre = "Ryobi"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 9,
                Nombre = "Metabo"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 10,
                Nombre = "Hilti"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 11,
                Nombre = "Ridgid"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 12,
                Nombre = "Craftsman"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 13,
                Nombre = "Porter-Cable"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 14,
                Nombre = "Festool"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 15,
                Nombre = "Worx"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 16,
                Nombre = "Kobalt"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 17,
                Nombre = "Skil"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 18,
                Nombre = "Dremel"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 19,
                Nombre = "Einhell"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 20,
                Nombre = "Rok"
            });

        }
    }
}
