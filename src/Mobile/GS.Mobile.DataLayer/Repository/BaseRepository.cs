// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Specific object to work with.
    /// </typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public BaseRepository(DbContext context)
        {
            this.CurrentContext = context;
        }

        /// <summary>
        /// Gets the current context being used.
        /// </summary>
        /// <returns>
        /// The <see cref="DbContext"/>.
        /// </returns>
        protected DbContext CurrentContext { get; }

        /// <inheritdoc />
        public async Task<IList<TEntity>> GetAllByPageAsync(int page = 1, int size = 100)
        {
            return await this.CurrentContext.Set<TEntity>().Skip((page - 1) * size).Take(size).ToListAsync();
        }

        /// <inheritdoc />
        public async Task AddAsync(TEntity entity)
        {
            await this.CurrentContext.Set<TEntity>().AddAsync(entity);
            await this.CurrentContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveAll()
        {
            var data = await this.CurrentContext.Set<TEntity>().ToListAsync();
            this.CurrentContext.Set<TEntity>().RemoveRange(data);
            await this.CurrentContext.SaveChangesAsync();
        }
    }
}