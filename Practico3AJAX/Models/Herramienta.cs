using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class Herramienta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo del modelo de la herramienta es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del modelo no puede exceder los 50 caracteres.")]
        public string Modelo { get; set; }

        [Required]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "La cantidad total de herramientas es obligatoria.")]
        public int CantidadTotal { get; set; }

        [Required(ErrorMessage = "El cantidad disponible de herramientas es obligatoria.")]
        public int Disponibles { get; set; }

        public virtual ICollection<UnidadHerramienta> UnidadHerramientas { get; set; }

    }
}