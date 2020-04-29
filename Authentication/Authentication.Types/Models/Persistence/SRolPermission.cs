// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SRolPermission.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SRolPermission type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security rol/permission.
    /// </summary>
    [Table("RolPermiso")]
    public class SRolPermission
    {
        /// <summary>
        /// Gets or sets the rol id.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Gets or sets the permission id.
        /// </summary>
        public int IdPermiso { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the row is active.
        /// </summary>
        public bool Activo { get; set; }
    }
}