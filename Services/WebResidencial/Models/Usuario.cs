using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebResidencial.Models
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private string usuario;
        private string contraseña;
        private bool activo;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string nUsuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}