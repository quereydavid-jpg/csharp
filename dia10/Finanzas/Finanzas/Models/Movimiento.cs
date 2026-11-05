using System.ComponentModel.DataAnnotations;
namespace Finanzas.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        [Display(Name = "Monto (Gs)")]
        [Range(1, 100000000, ErrorMessage = "El monto debe ser mayor igual a cero.")]
        public int Monto { get; set; }

        public TipoMovimiento Tipo { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [StringLength(200, ErrorMessage = "La descripcion admite hasta 200 caracteres.")]
        public string Descripcion { get; set; } = "";
    }
}
