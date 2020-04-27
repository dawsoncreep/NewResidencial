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
    public class SUbicacion
    {
        [Key]
        public int idUbicacion { get; set; }
        public string Nombre { get; set; }
        public int idTipoUbicacion { get; set; }
        public bool Activo { get; set; }
    }
}
