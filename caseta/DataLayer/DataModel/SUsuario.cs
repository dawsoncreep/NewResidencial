using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table("Usuario")]
    public class SUsuario
    {
        [Key]
        public int idUsuario{ get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string usuario { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
    }
}
