using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class Herramienta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } 

        [Required]
        public int IdMarca { get; set; }  

        [Required]
        public int CantidadTotal { get; set; }  

        [Required]
        public int Disponibles { get; set; }  

        
    }
}
