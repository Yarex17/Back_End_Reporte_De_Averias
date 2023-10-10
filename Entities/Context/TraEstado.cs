using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraEstado
{
    public int TnIdEstado { get; set; }

    public string TcNombre { get; set; } = null!;

    public bool TbActivo { get; set; }

    public bool TbEliminado { get; set; }

    public virtual ICollection<TraReporteTipoAveriaPrioridadEstadoOficina> TraReporteTipoAveriaPrioridadEstadoOficinas { get; set; } = new List<TraReporteTipoAveriaPrioridadEstadoOficina>();
}
