using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebResidencial.Models
{
    public class Evento
    {
        
        public int IdEvento { get; set; }
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "incio")]
        public DateTime? Inicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fin { get; set; }

        public string QR { get; set; }

        public int IdUbicacion { get; set; }
        
        public int Activo { get; set; }

        public bool BoolActivo
        { get { return Activo == 1; } set { Activo = value ? 1 : 0; } }

        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public List<Ubicacion> LstUbicaciones { get; set; }




    }
}