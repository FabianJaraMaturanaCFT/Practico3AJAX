using System.ComponentModel.DataAnnotations;

namespace EVA3AJAX.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la marca es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la marca no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        //public ICollection<Herramienta> Herramientas { get; set; }
    }
}