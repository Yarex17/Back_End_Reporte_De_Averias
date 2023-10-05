using System;
using System.Collections.Generic;

namespace Entities.Context
{
    public partial class TraReporteUsuario
    {
        public int TnIdReporte { get; set; }
        public int TnIdUsuario { get; set; }

        public virtual TraReporte TnIdReporteNavigation { get; set; }
        public virtual TraUsuario TnIdUsuarioNavigation { get; set; }
    }
}
