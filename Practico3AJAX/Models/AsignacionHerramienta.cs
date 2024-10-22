using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class AsignacionHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUnidadHerramienta { get; set; }  

        [Required]
        public int IdUsuario { get; set; }  

        [Required]
        public DateTime FechaAsignacion { get; set; }

        public DateTime? FechaDevolucion { get; set; }  

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }  
    }
}