using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class IngresoSalidaVisita
    {
        public Visita Visita { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string FotoPlacaDelantera { get; set; }
        public string FotoPlacaTrasera { get; set; }
        public string FotoCabina { get; set; }
        public string FotoIdentificacion { get; set; }
        public DateTime FechaSalida { get; set; }
        public string FotoSalidaUrl { get; set; }
    }
}
