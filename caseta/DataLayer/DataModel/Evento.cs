using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string QR { get; set; }
        [ForeignKey("idUbicacion")]
        public Ubicacion Ubicacion { get; set; }
        public bool Activo { get; set; }
    }
}
