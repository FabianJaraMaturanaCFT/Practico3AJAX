using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la marca es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de la marca no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }
    }
}
