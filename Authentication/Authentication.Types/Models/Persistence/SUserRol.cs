// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SUserRol.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SUserRol type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security user/rol.
    /// </summary>
    [Table("UsuarioRol")]
    public class SUserRol
    {
        /// <summary>
        /// Gets or sets the id usuario.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the rol id.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the row is active.
        /// </summary>
        public bool Activo { get; set; }
    }
}