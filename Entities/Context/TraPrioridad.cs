using System;
using System.Collections.Generic;

namespace Entities.Context
{
    public partial class TraPrioridad
    {
        public TraPrioridad()
        {
            TraReporte = new HashSet<TraReporte>();
        }

        public int TnIdPrioridad { get; set; }
        public string TcNombre { get; set; }
        public bool? TbActiva { get; set; }
        public bool TbEliminada { get; set; }

        public virtual ICollection<TraReporte> TraReporte { get; set; }
    }
}
