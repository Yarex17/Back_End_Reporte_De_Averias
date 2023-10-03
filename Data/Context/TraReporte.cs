using System;
using System.Collections.Generic;

namespace Data.Context
{
    public partial class TraReporte
    {
        public TraReporte()
        {
            TraReporteUsuario = new HashSet<TraReporteUsuario>();
        }

        public int TnIdReporte { get; set; }
        public int TnTipoAveria { get; set; }
        public int TnPrioridad { get; set; }
        public int TnEstado { get; set; }
        public int TnOficina { get; set; }
        public string TcDescripcion { get; set; }
        public DateTime TfFecha { get; set; }
        public bool? TbActivo { get; set; }
        public bool TbEliminado { get; set; }

        public virtual TraEstado TnEstadoNavigation { get; set; }
        public virtual TraOficina TnOficinaNavigation { get; set; }
        public virtual TraPrioridad TnPrioridadNavigation { get; set; }
        public virtual TraTipoAveria TnTipoAveriaNavigation { get; set; }
        public virtual ICollection<TraReporteUsuario> TraReporteUsuario { get; set; }
    }
}
