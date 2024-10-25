using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class UnidadHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El numero de serie es obligatorio.")]
        [StringLength(50, ErrorMessage = "El numero de serie no puede exceder los 50 caracteres.")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "El campo del estado de la unidad es obligatorio.")]
        public EstadoUnidad Estado { get; set; }  

        // Relación con Herramienta (Foreign Key)
        [ForeignKey("Herramienta")]
        public int IdModelo { get; set; }
        public virtual Herramienta Herramienta { get; set; }

        [Required(ErrorMessage = "Las fechas son obligatorias.")]
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