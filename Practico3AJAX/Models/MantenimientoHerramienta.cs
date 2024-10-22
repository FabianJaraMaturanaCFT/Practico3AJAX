using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class MantenimientoHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UnidadHerramienta")]
        public int IdUnidadHerramienta { get; set; }
        public virtual UnidadHerramienta UnidadHerramienta { get; set; }  

        [Required]
        public DateTime FechaInicio { get; set; }  

        public DateTime? FechaFin { get; set; }  

        public EstadoMantenimiento EstadoMantenimiento { get; set; } = EstadoMantenimiento.EnMantencion;
    }

    public enum EstadoMantenimiento
    {
        EnMantencion,
        MantencionFinalizada
    }
}