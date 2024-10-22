using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class UnidadHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroSerie { get; set; } 

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }  

        [Required]
        public int IdModelo { get; set; }  
    }
}