using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraReporte
{
    public int TnIdReporte { get; set; }

    public string TcDescripcion { get; set; } = null!;

    public DateTime TfFecha { get; set; }

    public bool? TbActivo { get; set; }

    public bool TbEliminado { get; set; }

    public virtual ICollection<TraReporteTipoAveriaPrioridadEstadoOficina> TraReporteTipoAveriaPrioridadEstadoOficinas { get; set; } = new List<TraReporteTipoAveriaPrioridadEstadoOficina>();

    public virtual ICollection<TraUsuario> TnIdUsuarios { get; set; } = new List<TraUsuario>();
}
