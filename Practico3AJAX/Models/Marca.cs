using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
