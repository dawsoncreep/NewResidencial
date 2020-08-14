// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SDevice.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SDevice type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security device
    /// </summary>
    [Table("Dispositivo")]
    class SDevice
    {
        /// <summary>
        /// Gets or sets Device id
        /// </summary>
        [Key]
        public int IdDispositivo { get; set; }
        /// <summary>
        /// Gets or set device Ip
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Gets or sets device user
        /// </summary>
        public int Usuario { get; set; }
        /// <summary>
        /// Gets or sets device pasword
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets location id
        /// </summary>
        public int IdUbicacion { get; set; }
        /// <summary>
        /// Gets or sets device state
        /// </summary>
        public bool Acitvo { get; set; }
        /// <summary>
        /// Gets or sets device port
        /// </summary>
        public string Purto { get; set; }
        /// <summary>
        /// Gets or sets device type
        /// </summary>
        public string TipoDispositvo { get; set; }
        /// <summary>
        /// Gets or set device protocol
        /// </summary>
        public string Protocolo { get; set; }
    }
}
