using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Visita
    {
        public int ID { get; set; }
        public TipoVisita TipoVisita { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Placas { get; set; }
        public string FotoURL { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public bool Activo { get; set; }
        public string QR { get; set; }
    }
}
