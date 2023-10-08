using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraUsuario
{
    public int TnIdUsuario { get; set; }

    public string TcRol { get; set; } = null!;

    public string TcNombre { get; set; } = null!;

    public string TcApellido { get; set; } = null!;

    public string TcCedula { get; set; } = null!;

    public string TcCorreo { get; set; } = null!;

    public string TcContrasennia { get; set; } = null!;

    public bool TbActivo { get; set; }

    public bool TbEliminado { get; set; }

    public virtual ICollection<TraOficina> TnIdOficinas { get; set; } = new List<TraOficina>();

    public virtual ICollection<TraReporte> TnIdReportes { get; set; } = new List<TraReporte>();
}
