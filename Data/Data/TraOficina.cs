using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class TraOficina
    {
        public TraOficina()
        {
            TraReporte = new HashSet<TraReporte>();
            TraUsuario = new HashSet<TraUsuario>();
        }

        public int TnIdOficina { get; set; }
        public int TnNumeroPiso { get; set; }
        public int TnEdificio { get; set; }
        public bool? TbActivo { get; set; }
        public bool TbEliminado { get; set; }

        public virtual TraEdificio TnEdificioNavigation { get; set; }
        public virtual ICollection<TraReporte> TraReporte { get; set; }
        public virtual ICollection<TraUsuario> TraUsuario { get; set; }
    }
}
