// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SFingerPrint.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SFingerPrint type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Huella")]
    public class SFingerPrint
    {
        /// <summary>
        /// Gets or sets id huella
        /// </summary>
        [Key]
        public int IdHuella { get; set; }
        /// <summary>
        /// Gets or sets Huella
        /// </summary>
        public byte[] Huella { get; set; }
        /// <summary>
        /// Gets or sets Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Gets or sets Fecha registro
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Gets or set Id personal
        /// </summary>
        public int IdPersonal { get; set; }
    }
}
