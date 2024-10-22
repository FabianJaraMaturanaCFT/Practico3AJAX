using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class AsignacionHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UnidadHerramienta")]
        public int IdUnidadHerramienta { get; set; }
        public virtual UnidadHerramienta UnidadHerramienta { get; set; }  

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }  

        [Required]
        public DateTime FechaAsignacion { get; set; }  

        public DateTime? FechaDevolucion { get; set; }  

        [Required]
        public EstadoAsignacion Estado { get; set; }  
    }

    // Enum para los posibles estados de la asignación
    public enum EstadoAsignacion
    {
        Activa,
        Devuelta
    }
}