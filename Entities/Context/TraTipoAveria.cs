using System;
using System.Collections.Generic;

namespace Entities.Context
{
    public partial class TraTipoAveria
    {
        public int TnIdTipoAveria { get; set; }

        public string? TcDescripcion { get; set; }

        public bool? TbActivo { get; set; }

        public bool TbEliminado { get; set; }

        public virtual ICollection<TraReporteTipoAveriaPrioridadEstadoOficina> TraReporteTipoAveriaPrioridadEstadoOficinas { get; set; } = new List<TraReporteTipoAveriaPrioridadEstadoOficina>();
    }
}
