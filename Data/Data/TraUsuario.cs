using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class TraUsuario
    {
        public TraUsuario()
        {
            TraReporteUsuario = new HashSet<TraReporteUsuario>();
        }

        public int TnIdUsuario { get; set; }
        public int TnOficina { get; set; }
        public string TcRol { get; set; }
        public string TcNombre { get; set; }
        public string TcApellido { get; set; }
        public string TcCedula { get; set; }
        public string TcCorreo { get; set; }
        public string TcContrasennia { get; set; }
        public bool? TbActivo { get; set; }
        public bool TbEliminado { get; set; }

        public virtual TraOficina TnOficinaNavigation { get; set; }
        public virtual ICollection<TraReporteUsuario> TraReporteUsuario { get; set; }
    }
}
