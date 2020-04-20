using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebResidencial.Models
{
    public class Ubicacion
    {
        //[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        [DisplayName("Id")]
        public int IdUbicacion { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        public TipoUbicacion TipoUbicacion { get; set; }
        public bool Activo { get; set; }

        public int IdTipoUbicacion { get; set; }
        public List<TipoUbicacion> TipoUbicacionList { get; set; }
        public string TipoUbicacionNombre { get; set; }
    }

    public class TipoUbicacion
    {
        public int IdTipoUbicacion { get; set; }

        [DisplayName("Tipo Ubicacion")]
        public string Nombre { get; set; }
    }
}