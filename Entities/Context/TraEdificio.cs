﻿using System;
using System.Collections.Generic;

namespace Entities.Context
{
    public partial class TraEdificio
    {
        public TraEdificio()
        {
            TraOficina = new HashSet<TraOficina>();
        }

        public int TnIdEdificio { get; set; }
        public string TcPropietario { get; set; }
        public string TcNombre { get; set; }
        public bool? TbActivo { get; set; }
        public bool TbEliminado { get; set; }

        public virtual ICollection<TraOficina> TraOficina { get; set; }
    }
}