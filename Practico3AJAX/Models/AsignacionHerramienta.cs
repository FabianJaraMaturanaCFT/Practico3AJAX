using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class AsignacionHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo de unidad de herramienta es obligatorio.")]
        [ForeignKey("UnidadHerramienta")]
        public int IdUnidadHerramienta { get; set; }
        public virtual UnidadHerramienta UnidadHerramienta { get; set; }  

        [Required(ErrorMessage = "El correo del usuario es obligatorio.")]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }  

        [Required(ErrorMessage = "Las fechas son obligatorias.")]
        public DateTime FechaAsignacion { get; set; }  

        public DateTime? FechaDevolucion { get; set; }  

        [Required(ErrorMessage = "El estado de asignacion es obligatorio.")]
        public EstadoAsignacion Estado { get; set; }  
    }

    // Enum para los posibles estados de la asignación
    public enum EstadoAsignacion
    {
        Activa,
        Devuelta
    }
}