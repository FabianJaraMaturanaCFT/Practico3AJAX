using EVA3AJAX.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EVA3AJAX.Models
{
    public class Herramienta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El modelo es requerido.")]
        [StringLength(100, ErrorMessage = "El modelo no puede exceder los 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "La marca es requerida.")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "La cantidad total es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad total debe ser mayor que cero.")]
        public int CantidadTotal { get; set; }

        [Required(ErrorMessage = "La cantidad disponible es requerida.")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad disponible no puede ser negativa.")]
        public int Disponibles { get; set; }

        //public Marca Marca { get; set; }
        //public ICollection<UnidadHerramienta> UnidadHerramientas { get; set; }

        public async Task<List<UnidadHerramienta>> ObtenerUnidadHerramientasAsync(ProyectoDBContext context)
        {
            return await context.UnidadHerramientas.Where(u => u.HerramientaId == this.Id).ToListAsync();
        }

    }
}
