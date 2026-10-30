using System;
using System.Collections.Generic;

namespace Cuentas.Models;

public partial class Division
{
    public int IdDivision { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
