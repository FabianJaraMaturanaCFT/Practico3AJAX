using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class AsignacionHerramienta
    {
        public int Id { get; set; }

        [ForeignKey("UnidadHerramienta")]
        public int UnidadHerramientaId { get; set; }
        public UnidadHerramienta UnidadHerramienta { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime FechaAsignacion { get; set; }

        public DateTime? FechaDevolucion { get; set; }
    }
}