// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SVehicle.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SVehicle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security Vehicle
    /// </summary>
    public class SVehicle
    {

        /// <summary>
        /// Gets or set id vehiculo
        /// </summary>
        [Key]
        public int IdVehiculo { get; set; }
        /// <summary>
        /// Gets or sets Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Gets or sets Placas
        /// </summary>
        public string Placas { get; set; }
        /// <summary>
        /// Gets or sets Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Gets or sets Tag
        /// </summary>
        public string Tag { get; set; }
    }
}
