// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SVehicleLocation.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SVehicleLocation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// The securiry VehicleLocation
    /// </summary>
    public class SVehicleLocation
    {
        /// <summary>
        /// Gets or sets id vehiculo
        /// </summary>
        public int IdVehiculo { get; set; }
        /// <summary>
        /// Gets or sets id ubicacion
        /// </summary>
        public int IdUbicacion { get; set; }
        /// <summary>
        /// Gets or sets Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Gets or set Fecha registro
        /// </summary>
        public DateTime FechaRegistro { get; set; }
    }
}
