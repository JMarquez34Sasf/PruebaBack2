using System;
using System.Collections.Generic;

namespace Cuentas.Models;

public partial class Cuenta
{
    public int IdCuenta { get; set; }

    public string NumeroCuenta { get; set; } = null!;

    public decimal Saldo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int IdDivision { get; set; }

    public int IdMoneda { get; set; }

    public virtual Division IdDivisionNavigation { get; set; } = null!;

    public virtual Monedum IdMonedaNavigation { get; set; } = null!;
}
