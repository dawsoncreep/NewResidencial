// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SUser.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SUser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security user.
    /// </summary>
    [Table("Usuario")]
    public class SUser
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [Key]
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        public string Celular { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        public bool Activo { get; set; }
    }
}