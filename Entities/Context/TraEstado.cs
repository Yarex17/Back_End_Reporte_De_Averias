using System;
using System.Collections.Generic;

namespace Entities.Context
{
    public partial class TraEstado
    {
        public TraEstado()
        {
            TraReporte = new HashSet<TraReporte>();
        }

        public int TnIdEstado { get; set; }
        public string TcNombre { get; set; }
        public bool? TbActivo { get; set; }
        public bool TbEliminado { get; set; }

        public virtual ICollection<TraReporte> TraReporte { get; set; }
    }
}
