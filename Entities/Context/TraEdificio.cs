using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraEdificio
{
    public int TnIdEdificio { get; set; }

    public string TcPropietario { get; set; } = null!;

    public string TcNombre { get; set; } = null!;

    public bool? TbActivo { get; set; }

    public bool TbEliminado { get; set; }

    public virtual ICollection<TraOficinaEdificio> TraOficinaEdificios { get; set; } = new List<TraOficinaEdificio>();

}
