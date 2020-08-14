// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SEvent.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security Event
    /// </summary>
    [Table("Evento")]
    public class SEvent
    {
        /// <summary>
        /// Gets or sets the event id
        /// </summary>
        [Key]
        public int IdEvento { get; set; }
        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Gets or sets the event start
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// Gets or sets the events end
        /// </summary>
        public DateTime Fin { get; set; }
        /// <summary>
        /// Gets or sets the event QR
        /// </summary>
        public string QR { get; set; }
        /// <summary>
        /// Gets or sets the location id
        /// </summary>
        public int IdUbicación { get; set; }
        /// <summary>
        /// Gets or sets the event status
        /// </summary>
        public int Activo { get; set; }
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public int IdUsuario { get; set; }
    }
}
