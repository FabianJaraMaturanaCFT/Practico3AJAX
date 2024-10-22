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
        public EstadoUnidad Estado { get; set; }  

        // Relación con Herramienta (Foreign Key)
        [ForeignKey("Herramienta")]
        public int IdModelo { get; set; }
        public virtual Herramienta Herramienta { get; set; }

        public DateTime? FechaIngreso { get; set; }  
        public DateTime? FechaRetornoBodega { get; set; }  
        public DateTime? FechaMantencion { get; set; }  
    }

    // Enum para los posibles estados de la unidad
    public enum EstadoUnidad
    {
        Disponible,
        EnUso,
        EnMantencion
    }
}