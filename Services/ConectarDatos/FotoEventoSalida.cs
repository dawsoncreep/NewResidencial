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
    
    public partial class FotoEventoSalida
    {
        public int idFotoEventoSalida { get; set; }
        public int idEvento { get; set; }
        public string placa { get; set; }
        public string fotoSalida { get; set; }
    
        public virtual Evento Evento { get; set; }
    }
}
