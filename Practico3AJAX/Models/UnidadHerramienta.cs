using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practico3AJAX.Models
{
    public class UnidadHerramienta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de serie es obligatorio.")]
        [StringLength(50, ErrorMessage = "El número de serie no puede exceder los 50 caracteres.")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "El estado de la unidad es obligatorio.")]
        public EstadoUnidad Estado { get; set; }

        [Required(ErrorMessage = "El modelo de la herramienta es obligatorio.")]
        [ForeignKey("Herramienta")]
        public int IdModelo { get; set; }
        public virtual Herramienta Herramienta { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRetornoBodega { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaMantencion { get; set; }
    }

    public enum EstadoUnidad
    {
        Disponible = 1,
        EnUso = 2,
        EnMantencion = 3
    }
}