using System.Collections.Generic;

namespace WebResidencial.Models
{
    public class UbicacionUsuario
    {
        public int IdUbicacion { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }

        public Ubicacion Ubicacion { get; set; }
        public Usuario Usuario { get; set; }

        public List<Ubicacion> UbicacionLst { get; set; }
        public List<Usuario> UsuariosLst { get; set; }

    }
}