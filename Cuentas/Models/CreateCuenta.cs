using System.ComponentModel.DataAnnotations;

namespace Cuentas.Models
{
    public class CreateCuenta
    {

        [Required(ErrorMessage ="N° cuenta requerido")]
        public string NumeroCuenta { get; set; } = null!;
        
        public decimal Saldo { get; set; }
        [Required(ErrorMessage ="Division Requerida")]
        public int IdDivision { get; set; }
        [Required(ErrorMessage ="Tipo de moneda requerida")]

        public int IdMoneda { get; set; }
    }
}
