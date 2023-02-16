﻿using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
