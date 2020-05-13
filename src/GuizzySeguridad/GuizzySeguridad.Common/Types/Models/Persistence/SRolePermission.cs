// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SRolePermission.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SRolePermission type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security rol/permission.
    /// </summary>
    [Table("RolPermiso")]
    public class SRolePermission
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