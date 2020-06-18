using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using SecureGateTypes;

namespace DataLayer
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public string ConnString { get; set; }
        public UsuarioRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public Usuario GetUsuario(string usuario, string contraseña)
        {
            Usuario user;
            using (IUsuarioDBContext context = new GeneralContext(ConnString))
            {
                user = context.Usuarios.Where(w => w.Activo == true && w.Contraseña == contraseña && usuario == usuario)
                    .Select(s => new Usuario {
                        ID = s.idUsuario
                    }).FirstOrDefault();
            }
            return user;
        }
    }
}
