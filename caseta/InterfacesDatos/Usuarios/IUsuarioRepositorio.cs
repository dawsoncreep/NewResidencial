using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureGateTypes;

namespace DataInterfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario GetUsuario(string usuario, string contraseña);
    }
}
