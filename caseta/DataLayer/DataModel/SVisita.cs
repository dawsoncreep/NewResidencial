using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("Visita")]
    public class SVisita
    {
        [Key]
        public int IdVisita { get; set; }
        public int idTipoVisita { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Placas { get; set; }
        public string FotoUrl { get; set; }
        public int idUbicacion { get; set; }
        public bool Activo { get; set; }
        public string QR { get; set; }
    }
}
