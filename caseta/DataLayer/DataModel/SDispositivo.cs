using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("Dispositivo")]
    public class SDispositivo
    {
        [Key]
        public int idDispositivo { get; set; }
        public string Ip { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int idUbicacion { get; set; }
        public bool activo { get; set; }
        public string puerto { get; set; }
        public string tipoDispositivo { get; set; }
        public string protocolo { get; set; }
    }
}
