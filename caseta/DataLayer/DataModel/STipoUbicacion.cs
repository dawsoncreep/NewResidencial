using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("tipoUbicacion")]
    public class STipoUbicacion
    {
        [Key]
        public int IdTipoUbicacion { get; set; }
        public string Nombre { get; set; }
    }
}
