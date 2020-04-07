using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table ("tipoUbicacion")]
    public class STipoUbicacion
    {
        [Key]
        public int IdTipoUbicacion { get; set; }
        public string Nombre { get; set; }
    }
}
