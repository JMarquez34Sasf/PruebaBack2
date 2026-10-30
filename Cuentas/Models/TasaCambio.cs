using System;
using System.Collections.Generic;

namespace Cuentas.Models;

public partial class TasaCambio
{
    public int IdCambio { get; set; }

    public int IdMonedaOrigen { get; set; }

    public int IdMonedaDestino { get; set; }

    public int TasaCambio1 { get; set; }

    public DateTime FechaCambio { get; set; }

    public virtual Monedum IdMonedaDestinoNavigation { get; set; } = null!;

    public virtual Monedum IdMonedaOrigenNavigation { get; set; } = null!;
}
