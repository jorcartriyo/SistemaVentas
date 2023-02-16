using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Descripcion { get; set; }

    public int? IdMenuPadre { get; set; }

    public string? Icono { get; set; }

    public string? Controlador { get; set; }

    public string? PaginaAccion { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Menu? IdMenuPadreNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; } = new List<Menu>();

    public virtual ICollection<Rolmenu> Rolmenus { get; } = new List<Rolmenu>();
}
