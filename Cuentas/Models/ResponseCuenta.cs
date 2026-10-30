namespace Cuentas.Models
{
    public class ResponseCuenta
    {
        public int IdCuenta { get; set; }

        public string NumeroCuenta { get; set; } = null!;

        public decimal Saldo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Division { get; set; }

        public string Moneda { get; set; }
    }
}
