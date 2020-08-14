// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SEntryEventPhoto.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SEntryEventPhoto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FotoEventoEntrada")]
    class SEntryEventPhoto
    {
        /// <summary>
        /// Gets or sets Events photo
        /// </summary>
        [Key]
        public int IdFotoEvento { get; set; }
        /// <summary>
        /// Gets or sets event id
        /// </summary>
        public int IdEvento { get; set; }
        /// <summary>
        /// Gets or sets Foto placa delantera
        /// </summary>
        public string FotoPlacaDelantera { get; set; }
        /// <summary>
        /// Gets or sets Foto placa trasera
        /// </summary>
        public string FotoPlacaTrasera { get; set; }
        /// <summary>
        /// Gets or sets Foto cabina
        /// </summary>
        public string FotoCabino { get; set; }
        /// <summary>
        /// Gets or sets foto identificación
        /// </summary>
        public string FotoIdentificacion { get; set; }
        /// <summary>
        /// Gets or sets Fecha ingreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Gets or sets Placa
        /// </summary>
        public string Placa { get; set; }
    }
}
