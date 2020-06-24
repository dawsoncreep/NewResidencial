// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SLocation.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SLocation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The s location.
    /// </summary>
    [Table("Ubicacion")]
    public class SLocation
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the location name
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the location type id
        /// </summary>
        public int IdTipoUbicacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheter is active
        /// </summary>
        public bool Activo { get; set; }


        // TODO: Add mor properties
    }
}