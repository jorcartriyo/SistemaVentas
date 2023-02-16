using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity;

public partial class Rolmenu
{
    public int IdRolMenu { get; set; }

    public int? IdRol { get; set; }

    public int? IdMenu { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
