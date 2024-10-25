using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico3AJAX.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del usuario no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo del usuario es obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono del usuario es obligatorio.")]
        [StringLength(15, ErrorMessage = "El numero del usuario no puede exceder los 15 caracteres.")]
        [Phone]  
        public string Telefono { get; set; }

        public virtual ICollection<AsignacionHerramienta> Asignaciones { get; set; }

        
        [NotMapped]
        public int CantidadHerramientasAsignadas => Asignaciones?.Count(a => a.FechaDevolucion == null) ?? 0;
    }
}