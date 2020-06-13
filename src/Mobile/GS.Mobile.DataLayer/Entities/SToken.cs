// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SToken.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SToken type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The token persistence entity.
    /// </summary>
    [Table(nameof(SToken))]
    public class SToken
    {
        /// <summary>
        /// Gets or sets the token id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the data(token).
        /// </summary>
        public string Data { get; set; }
    }
}