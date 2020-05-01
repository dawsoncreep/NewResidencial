using System.Collections.Generic;

namespace WebResidencial.Models
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public int IdTipoVisita { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Placas { get; set; }
        public string FotoUrl { get; set; }
        public int IdUbicacion { get; set; }
        public bool Activo { get; set; }
        public string QR { get; set; }

        public Ubicacion Ubicacion { get; set; }
        public TipoVisita TipoVisita { get; set; }
        public List<TipoVisita> LstTipoVisita { get; set; }

    }

    public class TipoVisita
    {
        public int IdTipoVisita { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}