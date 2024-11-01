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

        [Required(ErrorMessage = "La fecha de asignación es obligatoria.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaAsignacion { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaDevolucion { get; set; }

        [Required(ErrorMessage = "El estado de asignación es obligatorio.")]
        public EstadoAsignacion Estado { get; set; }
    }

    public enum EstadoAsignacion
    {
        Pendiente = 1,
        Activa = 2,
        Finalizada = 3
    }
}