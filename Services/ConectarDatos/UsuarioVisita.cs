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
    
    public partial class UsuarioVisita
    {
        public int idUsuario { get; set; }
        public int idVisita { get; set; }
        public System.DateTime fechaRegistro { get; set; }
        public bool activo { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Visita Visita { get; set; }
    }
}
