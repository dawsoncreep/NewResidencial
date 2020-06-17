using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("Evento")]
    public class SEvento
    {
        [Key]
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string QR { get; set; }
        public int idUbicacion { get; set; }
        public bool Activo { get; set; }
        public int idUsuario { get; set; }
    }
}
