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
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Acá se pueden cargar los datos iniciales de la base de datos

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                Nombre = "Fabian",
                Email = "matu69.ssj@gmail.com",
                Telefono = "961143118"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario 
            {
                Id = 3,
                Nombre = "Edgar",
                Email = "AAA.12@gmail.com",
                Telefono = "961145454"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 4,
                Nombre = "Ana",
                Email = "ana.hernandez@gmail.com",
                Telefono = "961145111"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 5,
                Nombre = "Carlos",
                Email = "carlos.martinez@hotmail.com",
                Telefono = "961142222"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 6,
                Nombre = "Lucia",
                Email = "lucia.gomez@yahoo.com",
                Telefono = "961144333"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 7,
                Nombre = "Raul",
                Email = "raul.rodriguez@outlook.com",
                Telefono = "961143444"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 8,
                Nombre = "Sofia",
                Email = "sofia.lopez@gmail.com",
                Telefono = "961145555"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 9,
                Nombre = "Miguel",
                Email = "miguel.sanchez@hotmail.com",
                Telefono = "961142666"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 10,
                Nombre = "Isabel",
                Email = "isabel.perez@gmail.com",
                Telefono = "961144777"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 11,
                Nombre = "Andres",
                Email = "andres.garcia@outlook.com",
                Telefono = "961143888"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 12,
                Nombre = "Marta",
                Email = "marta.flores@yahoo.com",
                Telefono = "961145999"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 13,
                Nombre = "Javier",
                Email = "javier.diaz@hotmail.com",
                Telefono = "961142000"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 3,
                Nombre = "Puma"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 4,
                Nombre = "Bosch"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 5,
                Nombre = "Makita"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 6,
                Nombre = "Dewalt"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 7,
                Nombre = "Stanley"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 8,
                Nombre = "Black & Decker"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 9,
                Nombre = "Hilti"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 10,
                Nombre = "Hitachi"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 11,
                Nombre = "Milwaukee"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 12,
                Nombre = "Ryobi"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 13,
                Nombre = "Craftsman"
            });

        }

    }

}