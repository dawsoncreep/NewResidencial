using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces
{
    public interface IUsuarioProcessor
    {
        bool UserExist(string usuario, string contraseña);
    }
}
