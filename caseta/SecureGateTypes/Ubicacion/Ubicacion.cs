﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Ubicacion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
    }
}
