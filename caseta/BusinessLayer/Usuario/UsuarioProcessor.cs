using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessInterfaces;
using DataInterfaces;

namespace BusinessLayer
{
    public class UsuarioProcessor : IUsuarioProcessor
    {
        private readonly IUsuarioRepositorio UsuarioRepositorio;
        public UsuarioProcessor(IUsuarioRepositorio _usuarioRepositorio)
        {
            UsuarioRepositorio = _usuarioRepositorio;
        }
        public bool UserExist(string usuario, string contraseña)
        {
            var user = UsuarioRepositorio.GetUsuario(usuario, contraseña);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
