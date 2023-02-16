using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Rolmenu> Rolmenus { get; } = new List<Rolmenu>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
