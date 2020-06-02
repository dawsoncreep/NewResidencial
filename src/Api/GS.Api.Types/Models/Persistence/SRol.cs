// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SRol.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SRol type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security rol.
    /// </summary>
    [Table("Rol")]
    public class SRol
    {
        /// <summary>
        /// Gets or sets the rol id.
        /// </summary>
        [Key]
        public int IdRol { get; set; }

        /// <summary>
        /// Gets or sets the rol name.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the rol is active.
        /// </summary>
        public bool Activo { get; set; }
    }
}