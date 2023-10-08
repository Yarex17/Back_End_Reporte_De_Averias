using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraPrioridad
{
    public int TnIdPrioridad { get; set; }

    public string TcNombre { get; set; } = null!;

    public bool TbActiva { get; set; }

    public bool TbEliminada { get; set; }

    public virtual ICollection<TraReporteTipoAveriaPrioridadEstadoOficina> TraReporteTipoAveriaPrioridadEstadoOficinas { get; set; } = new List<TraReporteTipoAveriaPrioridadEstadoOficina>();
}
