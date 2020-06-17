using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("tipoVisita")]
    public class STipoVisita
    {
        [Key]
        public int IdTipoVisita { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
