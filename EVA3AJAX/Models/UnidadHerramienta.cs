using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVA3AJAX.Models
{
    public class UnidadHerramienta
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de serie es requerido.")]
        [StringLength(50, ErrorMessage = "El número de serie no puede exceder los 50 caracteres.")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
        [RegularExpression("^(Disponible|En Uso|En Mantención)$", ErrorMessage = "El estado debe ser 'Disponible', 'En Uso' o 'En Mantención'.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La herramienta asociada es requerida.")]
        [ForeignKey("Herramienta")]
        public int HerramientaId { get; set; }

        //public virtual Herramienta Herramienta { get; private set; }

        /*public void SetHerramienta(Herramienta herramienta)
        {
            Herramienta = herramienta;
        }*/

    }

}
