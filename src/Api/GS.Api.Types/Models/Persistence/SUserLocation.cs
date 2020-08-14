// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SUserLocation.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SUserLocation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security user/location.
    /// </summary>
    [Table("UsuarioUbicacion")]
    public class SUserLocation
    {
        /// <summary>
        /// Gets or sets the id usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the id location
        /// </summary>
        public int IdUbicacion { get; set; }
    }
}
