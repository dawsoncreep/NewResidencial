using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table("Visita")]
    public class Visita
    {
        [Key]
        public int IdVisita { get; set; }
        [ForeignKey("idTipoVisita")]
        public TipoVisita TipoVisita { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Placas { get; set; }
        public string FotoUrl { get; set; }
        [ForeignKey("idUbicacion")]
        public Ubicacion Ubicacion { get; set; }
        public bool Activo { get; set; }
        public string QR { get; set; }
    }
}
