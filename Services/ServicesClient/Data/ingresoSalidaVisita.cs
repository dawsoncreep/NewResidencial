//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConectarDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ingresoSalidaVisita
    {
        public int idVisita { get; set; }
        public System.DateTime fechaIngreso { get; set; }
        public string fotoPlacaDelantera { get; set; }
        public string fotoPlacaTrasera { get; set; }
        public string fotoCabina { get; set; }
        public string fotoIdentificacion { get; set; }
        public Nullable<System.DateTime> fechaSalida { get; set; }
        public string fotoSalidaUrl { get; set; }
    
        public virtual Visita Visita { get; set; }
    }
}