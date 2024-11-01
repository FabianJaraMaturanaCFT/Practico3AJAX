using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVA3AJAX.Models
{
    public class AsignacionHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La unidad de herramienta es requerida.")]
        [ForeignKey("UnidadHerramienta")]
        public int UnidadHerramientaId { get; set; }
        //public UnidadHerramienta UnidadHerramienta { get; set; }

        [Required(ErrorMessage = "El usuario es requerido.")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; } 
        //public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha de asignación es requerida.")]
        public DateTime FechaAsignacion { get; set; }

    }
}
