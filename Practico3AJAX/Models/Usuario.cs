using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico3AJAX.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Phone]  
        public string Telefono { get; set; }

        public virtual ICollection<AsignacionHerramienta> Asignaciones { get; set; }

        // Esta propiedad no es mapeada a la base de datos, pero ayuda a contar las herramientas en uso
        [NotMapped]
        public int CantidadHerramientasAsignadas => Asignaciones?.Count(a => a.FechaDevolucion == null) ?? 0;
    }
}