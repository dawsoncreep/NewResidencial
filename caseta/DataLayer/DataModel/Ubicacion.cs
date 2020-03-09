using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table ("Ubicacion")]
    public class Ubicacion
    {
        [Key]
        public int IdUbicacion { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("idTipoUbicacion")]
        public TipoUbicacion TipoUbicacion { get; set; }
        public bool Activo { get; set; }
    }
}
