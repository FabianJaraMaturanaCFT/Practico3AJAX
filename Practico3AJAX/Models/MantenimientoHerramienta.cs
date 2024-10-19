using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class MantenimientoHerramienta
    {
        public int Id { get; set; }

        [ForeignKey("UnidadHerramienta")]
        public int UnidadHerramientaId { get; set; }
        public UnidadHerramienta UnidadHerramienta { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
    }
}
