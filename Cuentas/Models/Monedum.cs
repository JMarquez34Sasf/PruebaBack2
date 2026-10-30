using System;
using System.Collections.Generic;

namespace Cuentas.Models;

public partial class Monedum
{
    public int IdMoneda { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual ICollection<TasaCambio> TasaCambioIdMonedaDestinoNavigations { get; set; } = new List<TasaCambio>();

    public virtual ICollection<TasaCambio> TasaCambioIdMonedaOrigenNavigations { get; set; } = new List<TasaCambio>();
}
