// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SBulletin.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SBulletin type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The security Bulletin
    /// </summary>
    [Table("Boletin")]
    public class SBulletin
    {
        /// <summary>
        /// Gets or sets the bulletin id
        /// </summary>
        [Key]
        public int IdBoletin { get; set; }
        /// <summary>
        /// Gets or sets the bulletin mesage
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Gets or sets the bulletin state
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Gets or sets the bulletin registerDate
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Gets or sets the bulletin EndDate
        /// </summary>
        public DateTime FechaFin { get; set; }


    }
}
