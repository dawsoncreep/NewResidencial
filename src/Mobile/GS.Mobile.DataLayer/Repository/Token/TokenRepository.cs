// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Repository.Token
{
    using GS.Mobile.DataLayer.Entities;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The token repository.
    /// </summary>
    public class TokenRepository : BaseRepository<SToken>, ITokenRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public TokenRepository(DbContext context) : base(context)
        {
        }
    }
}