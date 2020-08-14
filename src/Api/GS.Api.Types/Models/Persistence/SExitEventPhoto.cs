// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SExitEventPhoto.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SExitEventPhoto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FotoEventoSalida")]
    public class SExitEventPhoto
    {
        /// <summary>
        /// Gets or sets Id foto evento salida
        /// </summary>
        [Key]
        public int IdFotoEventoSalida { get; set; }
        /// <summary>
        /// Gets or sets Id evento
        /// </summary>
        public int IdEvento { get; set; }
        /// <summary>
        /// Gets or sets placa
        /// </summary>
        public string Placa { get; set; }
        /// <summary>
        /// Gets or sets Foto salida
        /// </summary>
        public string FotoSalida { get; set; }
    }
}
