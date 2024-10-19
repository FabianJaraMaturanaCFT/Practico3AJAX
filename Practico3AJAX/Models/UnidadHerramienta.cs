using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class UnidadHerramienta
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroSerie { get; set; }

        [Required]
        public string Estado { get; set; } // disponible, en uso, en mantención

        [ForeignKey("Herramienta")]
        public int HerramientaId { get; set; }
        public Herramienta Herramienta { get; set; }
    }
}
