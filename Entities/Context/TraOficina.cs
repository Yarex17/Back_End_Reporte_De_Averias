using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraOficina
{
    public int TnIdOficina { get; set; }

    public int TnNumeroPiso { get; set; }

    public bool? TbActivo { get; set; }

    public bool TbEliminado { get; set; }

    public virtual ICollection<TraReporteTipoAveriaPrioridadEstadoOficina> TraReporteTipoAveriaPrioridadEstadoOficinas { get; set; } = new List<TraReporteTipoAveriaPrioridadEstadoOficina>();

    public virtual ICollection<TraUsuario> TnIdUsuarios { get; set; } = new List<TraUsuario>();
}
