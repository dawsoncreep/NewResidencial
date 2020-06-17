using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Dispositivo
    {
        public int IdDispositivo { get; set; }
        public string Ip { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public bool Activo { get; set; }
        public string Puerto { get; set; }
        public string TipoDispositivo { get; set; }
        public string Protocolo { get; set; }
    }
}
