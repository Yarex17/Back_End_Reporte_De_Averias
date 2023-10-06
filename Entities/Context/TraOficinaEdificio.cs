using System;
using System.Collections.Generic;

namespace Entities.Context;

public partial class TraOficinaEdificio
{
    public int TnIdEdificio { get; set; }

    public int TnIdOficina { get; set; }

    public virtual TraEdificio TnIdEdificioNavigation { get; set; } = null!;
}
