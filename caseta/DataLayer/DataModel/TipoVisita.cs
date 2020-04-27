using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table ("tipoVisita")]
    public class TipoVisita
    {
        [Key]
        public int IdTipoVisita { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
