// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SPermission.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SPermission type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The s permission.
    /// </summary>
    [Table("Permiso")]
    public class SPermission
    {
        /// <summary>
        /// Gets or sets the permission id.
        /// </summary>
        [Key]
        public int IdPermiso { get; set; }

        /// <summary>
        /// Gets or sets the permission name.
        /// </summary>
        public string Nombre { get; set; }    

        /// <summary>
        /// Gets or sets a value indicating whether the permission is active.
        /// </summary>
        public bool Activo { get; set; }
    }
}