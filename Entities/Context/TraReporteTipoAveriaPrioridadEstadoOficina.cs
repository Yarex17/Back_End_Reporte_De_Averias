using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraReporteTipoAveriaPrioridadEstadoOficina
{
    public int TnIdReporte { get; set; }

    public int TnIdTipoAveria { get; set; }

    public int TnIdPrioridad { get; set; }

    public int TnIdEstado { get; set; }

    public int TnIdOficina { get; set; }

    public virtual TraEstado TnIdEstadoNavigation { get; set; } = null!;

    public virtual TraOficina TnIdOficinaNavigation { get; set; } = null!;

    public virtual TraPrioridad TnIdPrioridadNavigation { get; set; } = null!;

    public virtual TraReporte TnIdReporteNavigation { get; set; } = null!;

    public virtual TraTipoAveria TnIdTipoAveriaNavigation { get; set; } = null!;
}
