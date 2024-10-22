using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class MantenimientoHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUnidadHerramienta { get; set; } 

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; } 
    }
}