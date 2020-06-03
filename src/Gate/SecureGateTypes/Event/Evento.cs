using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string QR { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public bool Activo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
