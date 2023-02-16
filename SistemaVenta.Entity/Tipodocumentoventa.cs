using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity;

public partial class Tipodocumentoventa
{
    public int IdTipoDocumentoVenta { get; set; }

    public string? Descripcion { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
