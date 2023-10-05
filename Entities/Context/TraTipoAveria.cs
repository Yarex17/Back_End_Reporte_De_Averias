using System;
using System.Collections.Generic;

namespace Entities.Context
{
    public partial class TraTipoAveria
    {
        public TraTipoAveria()
        {
            TraReporte = new HashSet<TraReporte>();
        }

        public int TnIdTipoAveria { get; set; }
        public string TcDescripcion { get; set; }
        public bool? TbActivo { get; set; }
        public bool TbEliminado { get; set; }

        public virtual ICollection<TraReporte> TraReporte { get; set; }
    }
}
