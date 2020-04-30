using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebResidencial.Models
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private string usuario;
        private string contraseña;
        private bool activo;

        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo de correo electrónico no es una dirección de correo electrónico válido.")]
        public string Correo { get; set; }

        [DisplayName("Télefono celular")]
        [Required(ErrorMessage = "El campo de télefono celular es obligatorio.")]
        public string Celular { get; set; }


        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get => nombre; set => nombre = value; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El campo de usuario es obligatorio.")]
        public string Usuario1 { get => usuario; set => usuario = value; }

        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}", MinimumLength = 6)]
        public string Contraseña { get => contraseña; set => contraseña = value; }

        public bool Activo { get => activo; set => activo = value; }
    }
}